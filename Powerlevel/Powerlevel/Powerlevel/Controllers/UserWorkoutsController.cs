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

        //random exercise generator
        public int GenRandomExercise(double BMI)
        {
            //random exercise generator engine
            //Underweight = < 18.5
            //Normal weight = 18.5–24.9
            //Overweight = 25–29.9
            //Obesity = BMI of 30 or greater

            //select multiple column example:
            //         var muscleGroupAbs = db.Exercises.Where(x => x.MainMuscleWorked == "Abs")
            //.Select(y => new List<string> { y.ExerciseId.ToString(), y.MainMuscleWorked }).ToList();

            //inital number/normal weight is 5, Underweight/OverWeight +1, Obesity +2
            int NumOfExercises = 5;

            if (BMI >= 25 && BMI <= 29.9)
            {
                NumOfExercises += 1;
            }
            if (BMI > 30)
            {
                NumOfExercises += 2;
            }

            Random randomMuscleGroupPicker = new Random();
            Random randomExercisePicker = new Random();
            int exercisePicker = 0;

            //inital List, for storing exercises
            List<int> exerciseList = new List<int>();

            //pick exercises
            for (int counter = 0; counter < NumOfExercises; counter++)
            {
                //random picker on choosing which muscleGroup to add
                int muscleGroup = randomMuscleGroupPicker.Next(0, 8);
                if (muscleGroup == 0)
                {
                    //grab all the exercises' id from db by muscle groups
                    var muscleGroupAbs = db.Exercises.Where(x => x.MainMuscleWorked == "Abs")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupAbs.Count);
                    exerciseList.Add(muscleGroupAbs[exercisePicker]); //append to list
                }
                if (muscleGroup == 1)
                {
                    var muscleGroupChest = db.Exercises.Where(x => x.MainMuscleWorked == "Chest")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupChest.Count);
                    exerciseList.Add(muscleGroupChest[exercisePicker]);
                }
                if (muscleGroup == 2)
                {
                    var muscleGroupLegs = db.Exercises.Where(x => x.MainMuscleWorked == "Legs")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupLegs.Count);
                    exerciseList.Add(muscleGroupLegs[exercisePicker]);
                }
                if (muscleGroup == 3)
                {
                    var muscleGroupBiceps = db.Exercises.Where(x => x.MainMuscleWorked == "Biceps")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupBiceps.Count);
                    exerciseList.Add(muscleGroupBiceps[exercisePicker]);
                }
                if (muscleGroup == 4)
                {
                    var muscleGroupGlutes = db.Exercises.Where(x => x.MainMuscleWorked == "Glutes")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupGlutes.Count);
                    exerciseList.Add(muscleGroupGlutes[exercisePicker]);
                }
                if (muscleGroup == 5)
                {
                    var muscleGroupCalves = db.Exercises.Where(x => x.MainMuscleWorked == "Calves")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupCalves.Count);
                    exerciseList.Add(muscleGroupCalves[exercisePicker]);
                }
                if (muscleGroup == 6)
                {
                    var muscleGroupUpperLegs = db.Exercises.Where(x => x.MainMuscleWorked == "Upper Legs")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupUpperLegs.Count);
                    exerciseList.Add(muscleGroupUpperLegs[exercisePicker]);
                }
                if (muscleGroup == 7)
                {
                    var muscleGroupLowerLegs = db.Exercises.Where(x => x.MainMuscleWorked == "Lower Legs")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupLowerLegs.Count);
                    exerciseList.Add(exercisePicker);
                }
                if (muscleGroup == 8)
                {
                    var muscleGroupUpperThighs = db.Exercises.Where(x => x.MainMuscleWorked == "Thighs")
                       .Select(y => y.ExerciseId).ToList();
                    exercisePicker = randomExercisePicker.Next(0, muscleGroupUpperThighs.Count);
                    exerciseList.Add(muscleGroupUpperThighs[exercisePicker]);
                }
            }

            //User testing = new User();     
            // testing.UserId = 2;
            //testing.UserName = "testing";
            //db.Users.Add(testing);

            //create new workout object
            Workout randomizeWorkout = new Workout();
            randomizeWorkout.Name = "Random Workouts";
            randomizeWorkout.Type = "Mixed";
            randomizeWorkout.MainMuscleFocus = "Mixed";
            randomizeWorkout.TimeEstimate = "60 Minutes";
            randomizeWorkout.ExpReward = 50;
            //insert a new record into the database
            db.Workouts.Add(randomizeWorkout);
            db.SaveChanges();

            //get randomizeWorkout WorkoutId
            var randWorkoutId = db.Workouts.Where(x => x.Name == "Random Workouts").Select(y => y.WorkoutId).FirstOrDefault();

            //create a new excise based on the generator engine
            WorkoutExercise randomizeWorkoutExercise = new WorkoutExercise();
            randomizeWorkoutExercise.WorkoutId = randWorkoutId;

            // insert data into database based on number of exercises generated
            for (int i = 0; i < NumOfExercises; i++)
            {
                randomizeWorkoutExercise.ExerciseId = exerciseList[i]; //add exercises based on the generated result
                randomizeWorkoutExercise.OrderNumber = i+1; //the order to do them in
                db.WorkoutExercises.Add(randomizeWorkoutExercise);
                db.SaveChanges();
            }

            //return the new random Workout Id back, in order to pass it as a parameters to start workouts
            return randWorkoutId;
        }





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


        // GET: Random
        [Authorize]
        public ActionResult Random()
        {

            double userBMI = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.BMI).FirstOrDefault();
            if (userBMI <= 0)
            {
                //return error if user didn't enter their infos
                ViewBag.BMI_Empty = "Error: You must enter your height and weight first before you can choose this workout option.";
                return View();
            }

            //remove existing/old random workouts
            var oldRandWorkout = db.Workouts.Where(x => x.Name == "Random Workouts").FirstOrDefault();
            if (oldRandWorkout != null)
            {
                //remove old random workouts
                db.Workouts.Remove(oldRandWorkout);
                db.SaveChanges();
            }           

            //generate random workouts
            int newRanWorkoutId = GenRandomExercise(userBMI);
         
            //start random workouts      
            return RedirectToAction("Create", new { id = newRanWorkoutId });
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


        // GET: UserWorkouts/Create
        public ActionResult Create(int? id)
        {
            //0 is not from workout plan
            int WorkoutFromPlan = 0;

            /*sets the default value for the dropdown list. If the view is being rendered from a workout plan call, then it sets default to id, else just 
             displays the first item in the dropdown list. It also sets FromPlan bool for recording plan stages after workout completion*/
            if (id == null)
            {
                ViewBag.FromPlan = false;
            }
            else
            {
                ViewBag.FromPlan = true;
                WorkoutFromPlan = (int)id;
            }

            //gets the current user of the application
            var CurrentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.UserId = CurrentUser.UserId;


            ViewBag.UserActiveWorkout = new SelectList(db.Workouts, "WorkoutId", "Name", WorkoutFromPlan);
            return View();
        }

        // POST: UserWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UWId,UserId,UserActiveWorkout")] UserWorkout userWorkout, bool fromPlan)
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

                return RedirectToAction("Progress", routeValues: new { id = uwid, fromPlan });
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", userWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(db.Workouts, "WorkoutId", "Name", userWorkout.UserActiveWorkout);
            return View(userWorkout);
        }

        /// <summary>
        /// The view that handles loading the Progress page to move through exercises in a workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Progress(int? id, bool fromPlan)
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
            //gets the total number of exercises in the workout to determine the final stage of the workout.
            int maxStage = InProgressWorkout.WorkoutExercises.Where(x => x.WorkoutId == UserWorkout.UserActiveWorkout).Count();

            //determines if the plan was completed
            bool PlanComplete = false;

            if (CurrentWorkoutStage == maxStage)
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
                Exercise ActiveExercise = db.WorkoutExercises.Where(x => x.WorkoutId == InProgressWorkout.WorkoutId && x.OrderNumber == UserWorkout.ActiveWorkoutStage + 1).Select(x => x.Exercise).First();

                //creates a view model that has the current exercise and the id for the currently active workout
                WorkoutVM CurrentExercise = new WorkoutVM
                {
                    CurrentExercise = ActiveExercise,
                    UWId = UserWorkout.UWId,
                    ActiveWorkoutStage = UserWorkout.ActiveWorkoutStage,
                    WorkoutName = UserWorkout.Workout.Name,
                    MaxWorkoutStage = maxStage,
                    UserActiveWorkout = UserWorkout.UserActiveWorkout,
                    FromPlan = fromPlan
                };

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

        /* This is no longer a function that changes the database, but rather just acts as a view that displays to the user 
         * what changes were made,  the function that actually changes the database is below titled "FinishedWorkout"
         * 
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
        */


        //This was replaced in favor of "ProgressForward" and "ProgressBack" functions, but left the code here for now
        /*
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
        */


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
        }

        /// <summary>
        /// Updates the current workout plan if there is one and returns if the plan is completed
        /// </summary>
        /// <param name="fromPlan"></param>
        public bool UpdatePlan()
        {
            //gets the active plan
            var userPlan = db.UserWorkoutPlans.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).First();

            //updates the current stage of the plan
            userPlan.PlanStage = userPlan.PlanStage + 1;

            //saves changes to the db
            db.Entry(userPlan).State = EntityState.Modified;
            db.SaveChanges();

            //checks if the plan has been completed
            if (userPlan.PlanStage == userPlan.MaxStage)
            {
                FinishPlan(userPlan);
                return (true);
            }

            return (false);
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
