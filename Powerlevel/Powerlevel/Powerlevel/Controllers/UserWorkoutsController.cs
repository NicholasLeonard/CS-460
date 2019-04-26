using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;
using Powerlevel.Models.ViewModels;
using Powerlevel.Infastructure;

namespace Powerlevel.Controllers
{

    public class UserWorkoutsController : Controller
    {
        private toasterContext db = new toasterContext();
        private IToasterRepository repo;

        public UserWorkoutsController(IToasterRepository repository)
        {
            this.repo = repository;
        }

        //user leveling algorithm logic function
        public void CheckUserLevel()
        {
            //get user current level
            int userCurrentLevel = repo.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Level).FirstOrDefault();

            //get user current exp
            int userCurrentExp = repo.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Experience).FirstOrDefault();

            //get the list of required exp for certain lv
            var expReqList = repo.LevelExps.Select(x => x.Exp).ToList();


            //formula for calculating user lv
            //if their exp is more than the current exp bracket of the level
            for (int counter = userCurrentLevel; counter < expReqList.Count(); counter++)
            {
                if (userCurrentExp >= expReqList[userCurrentLevel])
                {
                    userCurrentLevel += 1; //increase their level by 1
                }
            }

            //access user level info in the database
            var userData = db.Users.First(x => x.UserName == User.Identity.Name);
            userData.Level = userCurrentLevel;
            db.SaveChanges();
        }

        //Function for accessing database to update user exp
        public void AddExp(int expAmount)
        {

            //get the user current exp and add to it.
            int getCurrentExp = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Experience).FirstOrDefault();
            getCurrentExp += expAmount;

            //find the user column in the database and modified the existing value
            var userData = db.Users.First(x => x.UserName == User.Identity.Name);
            userData.Experience = getCurrentExp;
            db.SaveChanges();

            //calcalate the user level by their exp
            CheckUserLevel();
        }


        // GET: UserWorkouts
        public ActionResult Index()
        {
            var UserWorkouts = repo.UserWorkouts.Include(u => u.User).Include(u => u.Workout);
            return View(UserWorkouts.ToList());
        }

        // GET: UserWorkouts
        public ActionResult History()
        {
            var UserWorkouts = repo.UserWorkouts.Include(u => u.User).Include(u => u.Workout).OrderByDescending(u => u.CompletedTime);
            return View(UserWorkouts.ToList());
        }


        // GET: UserWorkouts/Create
        public ActionResult Create(int? id)
        {
            //0 is not from workout plan
            int WorkoutFromPlan = 0;

            /*sets the default value for the dropdown list. If the view is being rendered from a workout plan call, then it sets default to id, else just 
             displays the first item in the dropdown list. It also sets FromPlan bool for recording plan stages after workout completion*/
            if(id == null)
            {
                ViewBag.FromPlan = false;
            }
            else
            {
                ViewBag.FromPlan = true;
                WorkoutFromPlan = (int)id;
            }

            //gets the current user of the application
            var CurrentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.UserId = CurrentUser.UserId;
     

            ViewBag.UserActiveWorkout = new SelectList(repo.Workouts, "WorkoutId", "Name", WorkoutFromPlan);
            return View();
        }

        // POST: UserWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UWId,UserId,UserActiveWorkout")] UserWorkout userWorkout, bool fromPlan)
        {
            var currentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.First();

            if (ModelState.IsValid)
            {
                userWorkout.ActiveWorkoutStage = 0;
                db.UserWorkouts.Add(userWorkout);
                db.SaveChanges();
                //gets the UWId for the routing id to track in progress workouts
                var testuwid = repo.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.UWId).ToList();
                int uwid = testuwid.First();

                return RedirectToAction("Progress", routeValues: new { id = uwid, fromPlan });
            }

            ViewBag.UserId = new SelectList(repo.Users, "UserId", "UserName", userWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(repo.Workouts, "WorkoutId", "Name", userWorkout.UserActiveWorkout);
            return View(userWorkout);
        }

        /// <summary>
        /// The view that handles loading the Progress page to move through exercises in a workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Progress(int? id, bool fromPlan)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //gets the activeWorkout record for the user
            var UserWorkout = db.UserWorkouts.Find(id);
            //gets the active workout
            Workout InProgressWorkout = db.Workouts.Find(UserWorkout.UserActiveWorkout);
            //gets the stage of the active workout
            int CurrentWorkoutStage = UserWorkout.ActiveWorkoutStage;
            //gets the total number of exercises in the workout to determine the final stage of the workout.
            int maxStage = InProgressWorkout.WorkoutExercises.Where(x => x.WorkoutId == UserWorkout.UserActiveWorkout).Count();

            //determines if the plan was completed
            bool PlanComplete = false;

            if(CurrentWorkoutStage == maxStage)
            {
                //Marks workout as complete by setting WorkoutCompleted bool in table to true, *eventually* dispersing rewards like user exp
                FinishedWorkout(UserWorkout);

                //Updates the current stage of the plan, it is passing in the current workout id for plan completion
                if (fromPlan == true)
                {
                    PlanComplete = UpdatePlan();
                }
                
                //go to completed screen and distribute awards. Probably call the completed actionmethod here so it links in with Chi's exp code
                return RedirectToAction("Complete", routeValues: new { id, planComplete = PlanComplete });
            }
            else
            {
                //gets the current exercise in the workout by querying the workout/exercise transaction table. This iterates and returns all exercise except the first one everytime the next button is clicked
                Exercise ActiveExercise = repo.WorkoutExercises.Where(x => x.WorkoutId == InProgressWorkout.WorkoutId && x.OrderNumber == UserWorkout.ActiveWorkoutStage + 1).Select(x => x.Exercise).First();

                //creates a view model that has the current exercise and the id for the currently active workout
                WorkoutVM CurrentExercise = new WorkoutVM { CurrentExercise = ActiveExercise, UWId = UserWorkout.UWId, ActiveWorkoutStage = UserWorkout.ActiveWorkoutStage,
                    WorkoutName = UserWorkout.Workout.Name, MaxWorkoutStage = maxStage, UserActiveWorkout = UserWorkout.UserActiveWorkout, FromPlan = fromPlan};

                //returns the current exercise and if the plan was started from a workout plan or not
                
                return View(CurrentExercise);
            }
        }

        /// <summary>
        /// Used to move forward in a workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProgressForward(int? id, bool fromPlan)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserWorkout = db.UserWorkouts.Find(id);

            //changes the stage of the workout to the next exercise
            UserWorkout.ActiveWorkoutStage = UserWorkout.ActiveWorkoutStage + 1;

            //saves the changes in the db
            db.Entry(UserWorkout).State = EntityState.Modified;
            db.SaveChanges();

            //returns to the progress function to reload the progress view
            return RedirectToAction("Progress", new { id = UserWorkout.UWId, fromPlan });
        }

        /// <summary>
        /// Used to move backward in a workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProgressBack(int? id, bool fromPlan)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserWorkout = db.UserWorkouts.Find(id);

            //changes the stage of the workout to the previous exercise
            UserWorkout.ActiveWorkoutStage = UserWorkout.ActiveWorkoutStage - 1;

            //saves the changes in the db
            db.Entry(UserWorkout).State = EntityState.Modified;
            db.SaveChanges();

            //returns to the progress function to reload the progress view
            return RedirectToAction("Progress", new { id = UserWorkout.UWId, fromPlan });
        }

        // GET: UserWorkouts/Abandon/5
        public ActionResult Abandon(int? id, bool fromPlan)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            if (UserWorkout == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromPlan = fromPlan;
            return View(UserWorkout);
        }

        // POST: UserWorkouts/Abandon/5
        [HttpPost, ActionName("Abandon")]
        [ValidateAntiForgeryToken]
        public ActionResult AbandonConfirmed(int id, bool fromPlan)
        {
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            db.UserWorkouts.Remove(UserWorkout);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: UserWorkouts/Complete/5
        public ActionResult Complete(int? id, bool? planComplete)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            if (UserWorkout == null)
            {
                return HttpNotFound();
            }

            ViewBag.PlanComplete = planComplete;
            return View(UserWorkout);
        }        

        /// <summary>
        /// Sets the boolean value of WorkoutCompleted in UserWorkout to true
        /// </summary>
        /// <param name="UserWorkout"></param>
        public void FinishedWorkout(UserWorkout UserWorkout)
        {
            UserWorkout.WorkoutCompleted = true;

            //increase user exp by 50 on workout completion, right now exp reward is fixed at 50 per workout, might change it later
            AddExp(50);

            //saves change to db
            db.Entry(UserWorkout).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// <summary>
        /// Deletes user plan from the db
        /// </summary>
        public void FinishPlan(UserWorkoutPlan userPlan)
        {
            db.UserWorkoutPlans.Remove(userPlan);
            db.SaveChanges();

            //removes workout events for active plan once plan is complete so they are not displayed on the calendar
            RemoveWorkoutEvents();
        }

        /// <summary>
        /// Updates the current workout plan if there is one and returns if the plan is completed
        /// </summary>
        /// <param name="fromPlan"></param>
        public bool UpdatePlan()
        {
            //gets the active plan
            var userPlan = repo.UserWorkoutPlans.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).First();

            //updates the current stage of the plan
            userPlan.PlanStage = userPlan.PlanStage + 1;

            //saves changes to the db
            db.Entry(userPlan).State = EntityState.Modified;
            db.SaveChanges();
            
            //checks if the plan has been completed
            if(userPlan.PlanStage == userPlan.MaxStage)
            {
                FinishPlan(userPlan);
                return (true);
            }

            return (false);
        }

        public void RemoveWorkoutEvents()
        {
            //gets all of the associated workout events
            var Events = repo.WorkoutEvents.Where(x => x.User.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x);

            //removes all of the associated workout events from the db
            db.WorkoutEvents.RemoveRange(Events);
            db.SaveChanges();
        }

        /// <summary>
        /// Used to dispose of instances of the database when the controller exits
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
