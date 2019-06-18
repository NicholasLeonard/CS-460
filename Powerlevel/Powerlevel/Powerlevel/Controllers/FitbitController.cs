using Fitbit.Api.Portable.OAuth2;
using Fitbit.Api.Portable;
using Fitbit.Models;
using System;
using System.Net;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UnitsNet;
using UnitsNet.Units;
using Powerlevel.Models;
using Powerlevel.Infastructure;
using System.Data.Entity;

namespace Powerlevel.Controllers
{
    public class FitbitController : Controller
    {
        private toasterContext db = new toasterContext();
        private IToasterRepository repo;

        public FitbitController(IToasterRepository repository)
        {
            this.repo = repository;
        }
        //
        // GET: /Fitbit/

        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /FitbitAuth/
        // Setup - prepare the user redirect to Fitbit.com to prompt them to authorize this app.
        public ActionResult Authorize()
        {
            var appCredentials = new FitbitAppCredentials()
            {
                ClientId = ConfigurationManager.AppSettings["FitbitClientId"],
                ClientSecret = ConfigurationManager.AppSettings["FitbitClientSecret"]
            };
            //make sure you've set these up in Web.Config under <appSettings>:

            Session["AppCredentials"] = appCredentials;

            //Provide the App Credentials. You get those by registering your app at dev.fitbit.com
            //Configure Fitbit authenticaiton request to perform a callback to this constructor's Callback method
            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");
            string[] scopes = new string[] { "activity", "heartrate", "location", "nutrition", "profile", "settings", "sleep", "social", "weight" };

            string authUrl = authenticator.GenerateAuthUrl(scopes, null);

            var User = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if (User != null && User.FitbitLinked != true)
            {
                RecordFitbitLink(User);
            }
            

            return Redirect(authUrl);
        }

        /// <summary>
        /// Records that fitbit account is linked in user table for user
        /// </summary>
        /// <param name="user"></param>
        void RecordFitbitLink(User user)
        {
            user.FitbitLinked = true;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        //Final step. Take this authorization information and use it in the app
        public async Task<ActionResult> Callback()
        {
            //User CurrentUser = db.Users.Where(x => x.UserName == Thread.CurrentPrincipal.Identity.Name).FirstOrDefault();

            FitbitAppCredentials appCredentials = (FitbitAppCredentials)Session["AppCredentials"];

            var authenticator = new OAuth2Helper(appCredentials, Request.Url.GetLeftPart(UriPartial.Authority) + "/Fitbit/Callback");

            string code = Request.Params["code"];

            OAuth2AccessToken accessToken = await authenticator.ExchangeAuthCodeForAccessTokenAsync(code);

            //Store credentials in FitbitClient. The client in its default implementation manages the Refresh process
            var fitbitClient = GetFitbitClient(accessToken);

            //gets the current user profile from fitbit
            UserProfile FitBitProfile = await fitbitClient.GetUserProfileAsync();

            FitBitProfile = ConvertMeasurments(FitBitProfile);

            //sets height and weight in db based on fitbit profile           
            bool redirect = StoreCredentials(fitbitClient, FitBitProfile);
            
            if(redirect != true)
            {
                return View("~/Views/Home/Index.cshtml");
            }

            ViewBag.AccessToken = accessToken;

            return View("~/Views/Home/GettingStarted.cshtml");

        }

        /// <summary>
        /// Gets the FitBitProfile for the current session
        /// </summary>
        /// <param name="fitbitClient"></param>
        /// <returns></returns>
        public async Task<UserProfile> GetFitBitProfile(FitbitClient fitbitClient)
        {
            UserProfile FitBitProfile = await fitbitClient.GetUserProfileAsync();
            FitBitProfile = ConvertMeasurments(FitBitProfile);
            return (FitBitProfile);
        }

        /// <summary>
        /// Stores the api access tokens in the db and returns bool based on storage success
        /// </summary>
        /// <param name="accessToken"></param>
        bool StoreCredentials(FitbitClient fitbitClient, UserProfile userProfile)
        {//gets the user that is logging in
            User ourUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            
            if (ourUser.Weight == null || ourUser.HeightFeet == null)
            {//sets the height and weight components of the user off of the fitbit profile
                ourUser.HeightFeet = (int)userProfile.Height/12;
                ourUser.HeightInch = (int)userProfile.Height % 12;
                ourUser.Weight = userProfile.Weight;
                db.Entry(ourUser).State = EntityState.Modified;
                db.SaveChanges();

                //Performs BMI calculation off of newly set height and weight for user
                Models.StaticClasses.SetUserBMI.SetBMI(ourUser, db);
                return true;
            }
            return false;
        }
        
        /// <summary>
        /// In this example we show how to explicitly request a token refresh. However, FitbitClient V2 on its default implementation provide an OOB automatic token refresh.
        /// </summary>
        /// <returns>A refreshed token</returns>
        public async Task<ActionResult> RefreshToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = await fitbitClient.RefreshOAuth2TokenAsync(); //fitbitClient.RefreshOAuth2Token(); //Had to change this from original cause it wasn't showing up

            return View("Callback");
        }

        public async Task<ActionResult> TestToken()
        {
            var fitbitClient = GetFitbitClient();

            ViewBag.AccessToken = fitbitClient.AccessToken;

            UserProfile test = await fitbitClient.GetUserProfileAsync();

            return View(test);
        }

        /// <summary>
        /// Displays page for entering number of calories that were burned during the Powerlevel workout
        /// </summary>
        /// <param name="userWorkoutId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult RecordActivity(int? userWorkoutId)
        {
            ViewBag.UserWorkoutId = userWorkoutId;
            return View();
        }

        /// <summary>
        /// Actionresult that handles request to fitbit API to record powerlevel workout log
        /// </summary>
        /// <param name="userWorkoutId"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RecordActivity(int Calories, int? userWorkoutId)
        {
            if(userWorkoutId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //makes sure nonnegative calorie count
            if(Calories < 0)
            {
                ModelState.AddModelError("", "Calories cannot be a negative number");
                return View();
            }

            //gets a new fitbitclient instance
            FitbitClient fitbitClient = GetFitbitClient();

            //gets the completed workout that the user wants to log to fitbit
            UserWorkout CompletedWorkout = db.UserWorkouts.Find(userWorkoutId);

            //gets a newly construted fitbit activitylog to be recorded to the api
            ActivityLog ActivityLog = NewActivityLog(CompletedWorkout, Calories);

            var APIResponse = await fitbitClient.LogActivityAsync(ActivityLog);
            
            //sets response message based on result
            if(APIResponse != null)
            {
                ViewBag.Result = "Successfully logged activity.";
            }
            else
            {
                ViewBag.Result = "Unable to log activity.";
            }
            return View("APIResponse");
        }

        /// <summary>
        /// Returns a new fitbit activitylog based on the completed userworkout
        /// </summary>
        /// <param name="completedWorkout"></param>
        /// <returns></returns>
        ActivityLog NewActivityLog(UserWorkout completedWorkout, int calories)
        {//initializes the new activity log, adjust calorie calculation based on bmi
            ActivityLog NewLog = new ActivityLog { Calories = calories, Date = DateTime.Today.ToString("yyyy-MM-dd"), Name = "Powerlevel Workouts",
                StartTime = completedWorkout.StartTime.ToString("HH:mm:ss"),
                Duration = Math.Abs((long)(completedWorkout.CompletedTime - completedWorkout.StartTime).TotalMilliseconds), Distance = 1.0f};

            return NewLog;
        }

        /// <summary>
        /// Converts from kg to lb and cm to ft for user height and weight
        /// </summary>
        /// <param name="fitBitUser"></param>
        /// <returns></returns>
        UserProfile ConvertMeasurments(UserProfile fitBitUser)
        {//converst weight from kg to lb and rounds to 2 decimal places
            Mass Weight = Mass.FromKilograms(fitBitUser.Weight);
            fitBitUser.Weight = Math.Round(Weight.ToUnit(MassUnit.Pound).Pounds, 2);

            //converts height from cm to ft and rounds to 2 decimal places
            Length Height = Length.FromCentimeters(fitBitUser.Height);
            fitBitUser.Height = Height.ToUnit(LengthUnit.Inch).Inches;
            
            return (fitBitUser);
        }

        public async Task<ActionResult> LastWeekSteps()
        {

            FitbitClient client = GetFitbitClient();

            var response = await client.GetTimeSeriesIntAsync(TimeSeriesResourceType.Steps, DateTime.UtcNow.AddDays(-7), DateTime.UtcNow);

            return View(response);

        }

        /// <summary>
        /// HttpClient and hence FitbitClient are designed to be long-lived for the duration of the session. This method ensures only one client is created for the duration of the session.
        /// More info at: http://stackoverflow.com/questions/22560971/what-is-the-overhead-of-creating-a-new-httpclient-per-call-in-a-webapi-client
        /// </summary>
        /// <returns></returns>
        private FitbitClient GetFitbitClient(OAuth2AccessToken accessToken = null)
        {
            if (Session["FitbitClient"] == null)
            {
                if (accessToken != null)
                {
                    var appCredentials = (FitbitAppCredentials)Session["AppCredentials"];
                    FitbitClient client = new FitbitClient(appCredentials, accessToken);
                    Session["FitbitClient"] = client;
                    return client;
                }
                else
                {
                    throw new Exception("First time requesting a FitbitClient from the session you must pass the AccessToken.");
                }

            }
            else
            {
                return (FitbitClient)Session["FitbitClient"];
            }
        }
    }
}