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

namespace Powerlevel.Controllers
{

    public class UserWorkoutsController : Controller
    {
        private toasterContext db = new toasterContext();

        //user leveling algorithm logic function
        public void CheckUserLevel()
        {
            //get user current level
            int userCurrentLevel = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Level).FirstOrDefault();

            //get user current exp
            int userCurrentExp = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Experience).FirstOrDefault();

            //get the list of required exp for certain lv
            var expReqList = db.LevelExps.Select(x => x.Exp).ToList();


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
            var UserWorkouts = db.UserWorkouts.Include(u => u.User).Include(u => u.Workout);
            return View(UserWorkouts.ToList());
        }

        // GET: UserWorkouts
        public ActionResult History()
        {
            var UserWorkouts = db.UserWorkouts.Include(u => u.User).Include(u => u.Workout).OrderByDescending(u => u.CompletedTime);
            return View(UserWorkouts.ToList());
        }

        // GET: UserWorkouts/Details/5
        public ActionResult Details(int? id)
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
            return View(UserWorkout);
        }

        // GET: UserTestWorkouts/Create
        public ActionResult Create()
        {
            var CurrentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.UserId = CurrentUser.UserId;

            ViewBag.UserActiveWorkout = new SelectList(db.Workouts, "WorkoutId", "Name");
            return View();
        }

        // POST: UserTestWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UWId,UserId,UserActiveWorkout")] UserWorkout userWorkout)
        {
            var currentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.First();

            if (ModelState.IsValid)
            {
                userWorkout.ActiveWorkoutStage = 0;
                db.UserWorkouts.Add(userWorkout);
                db.SaveChanges();
                //gets the UWId for the routing id to track in progress workouts
                var testuwid = db.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.UWId).ToList();
                int uwid = testuwid.First();

                return RedirectToAction("Progress", routeValues: new { id = uwid });
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", userWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(db.Workouts, "WorkoutId", "Name", userWorkout.UserActiveWorkout);
            return View(userWorkout);
        }

        /*
         * 
        // POST: UserWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workout Workout)
        {//gets the current userid to be added to the userworkout table
            var currentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.First();

            if (ModelState.IsValid)
            {//uses the returned workout to start to create a new active entry in the userworkout table
                UserWorkout ActiveUserWorkout = new UserWorkout { UserId = userId, UserActiveWorkout = Workout.WorkoutId, WorkoutCompleted = false,
                    ActiveWorkoutStage = 0};
                db.UserWorkouts.Add(ActiveUserWorkout);
                db.SaveChanges();
                //gets the UWId for the routing id to track in progress workouts
                var testuwid = db.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.UWId).ToList();
                int uwid = testuwid.First();
                
                return RedirectToAction("Progress", routeValues: new { id = uwid });
            }
            *
            */

        /*ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", UserWorkout.UserId);
        ViewBag.UserActiveWorkout = new SelectList(db.WorkoutExercises, "LinkId", "LinkId", UserWorkout.UserActiveWorkout);*/
        /*
        return View(Workout);
    }
    */

        /// <summary>
        /// Called when progressing forward through a workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Progress(int? id)
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

            if(CurrentWorkoutStage == maxStage)
            {
                //go to completed screen and distribute awards. Probably call the completed actionmethod here so it links in with Chi's exp code
                return RedirectToAction("Index");
            }
            else
            {
                //gets the current exercise in the workout by querying the workout/exercise transaction table. This iterates and returns all exercise except the first one everytime the next button is clicked
                Exercise ActiveExercise = db.WorkoutExercises.Where(x => x.WorkoutId == InProgressWorkout.WorkoutId && x.OrderNumber == UserWorkout.ActiveWorkoutStage + 1).Select(x => x.Exercise).First();

                //creates a view model that has the current exercise and the id for the currently active workout
                WorkoutVM CurrentExercise = new WorkoutVM { CurrentExercise = ActiveExercise, UWId = UserWorkout.UWId};

                //changes the stage of the workout to the next exercise, 1 is forward
                ChangeWorkoutStage(UserWorkout, 1);

                //returns the current exercise
                return View(CurrentExercise);
                
            }
        }

        /// <summary>
        /// Used to proceed backward in a workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ProgressBack(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //gets the activeWorkout record for the user
            var UserWorkout = db.UserWorkouts.Find(id);

            //gets the active workout
            Workout InProgressWorkout = db.Workouts.Find(UserWorkout.UserActiveWorkout);

            //gets the stage of the active workout
            int CurrentWorkoutStage = UserWorkout.ActiveWorkoutStage;

            //redirects to normal Progress method to start from the beginning
            if (CurrentWorkoutStage == 0)
            {//gets the current exercise in the workout by querying the workout/exercise transaction table. This returns the first exercise in the workout
                return RedirectToAction("Progress", new { id = UserWorkout.UWId });
            }
            else
            {
                //gets the current exercise in the workout by querying the workout/exercise transaction table. This iterates and returns all exercise except the first one everytime the next button is clicked
                Exercise ActiveExercise = db.WorkoutExercises.Where(x => x.WorkoutId == InProgressWorkout.WorkoutId && x.OrderNumber == UserWorkout.ActiveWorkoutStage + 1).Select(x => x.Exercise).First();

                //creates a view model that has the current exercise and the id for the currently active workout
                WorkoutVM CurrentExercise = new WorkoutVM { CurrentExercise = ActiveExercise, UWId = UserWorkout.UWId };

                //changes the stage of the workout to the next exercise, -1 is backward
                ChangeWorkoutStage(UserWorkout, -1);

                //returns the current exercise
                return View(CurrentExercise);

            }
        }

        // GET: UserWorkouts/Abandon/5
        public ActionResult Abandon(int? id)
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
            return View(UserWorkout);
        }

        // POST: UserWorkouts/Abandon/5
        [HttpPost, ActionName("Abandon")]
        [ValidateAntiForgeryToken]
        public ActionResult AbandonConfirmed(int id)
        {
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            db.UserWorkouts.Remove(UserWorkout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: UserWorkouts/Complete/5
        public ActionResult Complete(int? id)
        {
            ViewBag.workoutId = 0;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);
            if (UserWorkout == null)
            {
                return HttpNotFound();
            }
            return View(UserWorkout);
        }

        // POST: UserWorkouts/Complete/5
        [HttpPost, ActionName("Complete")]
        [ValidateAntiForgeryToken]
        public ActionResult CompleteConfirmed(int id)
        {
            UserWorkout UserWorkout = db.UserWorkouts.Find(id);

            //Marks the current workout as "Completed", moving it from the User's Active Workout tab to the Workout History tab
            var completedWorkout = new UserWorkout { UserId = UserWorkout.UserId, UserActiveWorkout = UserWorkout.UserActiveWorkout, WorkoutCompleted = true };
            db.UserWorkouts.Add(completedWorkout);

            //"Removes" the old table, as the new one is essentially a duplicate with a WorkoutCompleted value of True, instead of False
            db.UserWorkouts.Remove(UserWorkout);
            db.SaveChanges();

            //increase user exp by 50 on workout completion, right now exp reward is fixed at 50 per workout, might change it later
            AddExp(50);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Used to change the stage in a workout
        /// </summary>
        /// <param name="UserWorkout"></param>
        /// <param name="direction"></param>
        public void ChangeWorkoutStage(UserWorkout UserWorkout, int direction)
        {
            //changes the stage of the workout to the next exercise
            UserWorkout.ActiveWorkoutStage = UserWorkout.ActiveWorkoutStage + direction;

            //saves the changes in the db
            db.Entry(UserWorkout).State = EntityState.Modified;
            db.SaveChanges();
        }

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
