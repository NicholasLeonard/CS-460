using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Diagnostics;
using System.Web.Mvc;
using System.Data.Entity;
using Powerlevel.Models;
using Powerlevel.Infastructure;


namespace Powerlevel.Controllers
{
    public class UserController : Controller
    {//for database access
        private toasterContext db = new toasterContext();
        private IToasterRepository repo;

        public UserController(IToasterRepository repository)
        {
            this.repo = repository;
        }

        /// <summary>
        /// Gets the current user and displays a page for them to enter height and weight
        /// </summary>
        /// <returns></returns>
        // GET: User
        public ActionResult Index()
        {
            User user = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("Index", "Home", null);
            }
            return View(user);
        }


        /// <summary>
        /// Used to adjust metrics after they have been entered
        /// </summary>
        /// <param name="currentUserMetrics"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserId, HeightFeet, HeightInch, Weight, UserName")] User currentUserMetrics)
        {//this gets the field for the current user that is entering their metrics
            if (ModelState.IsValid)
            {
                //makes sure that inch component of height isn't greater than 11
                if(currentUserMetrics.HeightInch > 11)
                {
                    ModelState.AddModelError("", "Inch component can't be greater than 11");
                    return View();
                }

                if (currentUserMetrics.HeightFeet <= 0)
                {
                    ModelState.AddModelError("", "Invalid Feet.");
                    return View();
                }

                if (currentUserMetrics.HeightInch < 0)
                {
                    ModelState.AddModelError("", "Invalid Inches.");
                    return View();
                }

                if (currentUserMetrics.Weight <= 0)
                {
                    ModelState.AddModelError("", "Invalid weight.");
                    return View();
                }

                if (currentUserMetrics.Weight == null || currentUserMetrics.HeightFeet == null|| currentUserMetrics.HeightInch == null)
                {
                    ModelState.AddModelError("", "Please fill out all the fields.");
                    return View();
                }

                //gets the entry from the db
                User metrics = db.Users.Find(currentUserMetrics.UserId);

                //updates the values in the entry
                metrics.HeightFeet = currentUserMetrics.HeightFeet;
                metrics.HeightInch = currentUserMetrics.HeightInch;
                metrics.Weight = currentUserMetrics.Weight;

                //saves the changes to the db
                db.Entry(metrics).State = EntityState.Modified;


                //calculate user BMI on submit                
                Models.StaticClasses.SetUserBMI.SetBMI(metrics, db);
            }

            return RedirectToAction("Index", "Manage", null);
        }

        /// <summary>
        /// party/team system, join functionality
        /// </summary>
        /// <returns></returns>
        [HttpGet][Authorize]
        public ActionResult JoinTeam(int id)
        {
            //get current loggedin userID
            int currentUserId = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //check for duplicates
            var duplicateUser = db.Teams.Where(x => x.TeamId == currentUserId && x.TeamMemId == id).FirstOrDefault();

            //safety check: make sure user is not partying up with themselves
            if (currentUserId != id && duplicateUser == null)
            {
                Team teamObject = new Team();
                teamObject.UserId = currentUserId;
                teamObject.TeamMemId = id;
                db.Teams.Add(teamObject); //add to the db

                Team peerTeamObject = new Team(); //peer user also added to the db
                peerTeamObject.UserId = id;
                peerTeamObject.TeamMemId = currentUserId;
                db.Teams.Add(peerTeamObject); //add to the db

                db.SaveChanges();
            }
            return RedirectToAction("Profiles", "User", id);
        }

        /// <summary>
        /// party/team system, join functionality
        /// </summary>
        /// <returns></returns>
     
        [HttpGet][Authorize]
        public ActionResult LeaveTeam(int id)
        {
            //get current loggedin userID
            int currentUserId = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            if (currentUserId != id)
            {

                //delete the row in the database for the current user
                var teamObj = db.Teams.Where(x => x.UserId == currentUserId && x.TeamMemId == id).FirstOrDefault();
                if (teamObj != null)
                {
                    db.Teams.Remove(teamObj);
                    db.SaveChanges();
                }

                //delete the row in the database for the peer user
                var peerTeamObj = db.Teams.Where(x => x.UserId == id && x.TeamMemId == currentUserId).FirstOrDefault();
                if (peerTeamObj != null)
                {
                    db.Teams.Remove(peerTeamObj);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Profiles", "User", id);
        }

        /// <summary>
        /// Displays other user's profile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Profiles(int? id)
        {
            User userObject = new User();
            userObject = db.Users.Find(id); //find by primary key id

            //fail safe page redirect
            if (id == null || userObject == null)
            {
                return RedirectToAction("Index", "Manage", null); //redirect user if null or id not found
            }

            ViewBag.userName = userObject.UserName; //pass the data into a viewbag, get data by ID
            ViewBag.level = userObject.Level;
            ViewBag.exp = userObject.Experience;
            ViewBag.heightFeet = userObject.HeightFeet;
            ViewBag.heightInch = userObject.HeightInch;
            ViewBag.weight = userObject.Weight;
            ViewBag.BMI = userObject.BMI;
            ViewBag.userAvatarBody = userObject.UserAvatars.ElementAt(0).Body; //get the first body element of the ICollection in index 0 

            //get current loggedin userID
            int currentUserId = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //check if the current user is already team'd up
            var currentUserInTeam = db.Teams.Where(x => x.UserId == currentUserId).Select(y => y.TeamMemId).FirstOrDefault();

            //check if the current user is already team'd up with the same peer
            var peerUserInTeam = db.Teams.Where(x => x.UserId == currentUserId).Select(y => y.TeamMemId).ToList();
             

            //check if the other user is in the same team
            if (id != currentUserId) //if null, user is not team'd up with currentUser
            {
                //pass the other user id into viewbag for view
                ViewBag.TeamURL = "/user/joinTeam/" + id;
                ViewBag.TeamupMessage = ">>TEAM UP<<";
            }

            int isInTeam = 0;
            //check the list and see if the peer is in the team with the leader
            for (int i = 0; i < peerUserInTeam.Count(); i++)
            {
                if (peerUserInTeam[i] == id)
                {
                    isInTeam = 1;
                }
            }
            if (currentUserInTeam != null && id != currentUserId && isInTeam == 1)
            {
                ViewBag.TeamURL = "/user/leaveTeam/" + id;
                ViewBag.TeamupMessage = ">>LEAVE TEAM<<";
            }
            if (currentUserInTeam != null && id == currentUserId)
            {
                ViewBag.TeamURL = "";
                ViewBag.TeamupMessage = "You can't team up with yourself.";
            }//if there is no one else to team up with, displays message.
            if (currentUserInTeam == null && id == currentUserId)
            {
                ViewBag.TeamURL = "";
                ViewBag.TeamupMessage = "You can't team up with yourself.";
            }
            return View();
        }



        /// <summary>
        /// Displays the current user's metrics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Display()
        {//gets the metrics of the current user
            var currentUser = HttpContext.User.Identity.Name;

            if (currentUser != null)
            {//displays the current user metrics
                User currentUserMetrics = db.Users.Where(x => x.UserName == currentUser).FirstOrDefault();
                return View(currentUserMetrics);
            }
            //if there is an error it displays on the account page with an error
            ManageController.ManageMessageId message = ManageController.ManageMessageId.Error;
            return RedirectToAction("Index", "Account", message);
        }

        /// <summary>
        /// Garbage collection method for disposing of database access when the controller has finished executing
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}