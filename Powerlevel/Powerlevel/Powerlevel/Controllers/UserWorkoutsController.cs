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
                randomizeWorkoutExercise.ExerciseId = (exerciseList[i] == 0) ? 1 : exerciseList[i]; //add exercises based on the generated result
                randomizeWorkoutExercise.OrderNumber = i + 1; //the order to do them in
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
            //get current Logged-in user Id
            var currentUserId = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();

            //check if user is in a team
            var teamMembers = db.Teams.Where(x => x.UserId == currentUserId).Select(y => y.TeamMemId).ToArray();

            //if user have team members 1.5x exp bonus & all team members get 50% exp
            if (teamMembers.Count() != 0)
            {
                //in a team, the current user get 200% bonus exp
                //get the user current exp and add to it.
                int getCurrentExp = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Experience).FirstOrDefault();
                getCurrentExp += (expAmount * 2);

                //find the user column in the database and modified the existing value
                var userData = db.Users.First(x => x.UserName == User.Identity.Name);
                userData.Experience = getCurrentExp;
                db.SaveChanges();

                //all team members get 50% of exp
                for (int i = 0; i < teamMembers.Count(); i++)
                {
                    User teamMemberObject = new User();
                    teamMemberObject = db.Users.Find(teamMembers[i]);
                    teamMemberObject.Experience += (expAmount / 2);
                    db.SaveChanges();
                }
            }
            else
            {
                //not in a team, get only 100% of exp, no bonus 
                //get the user current exp and add to it.
                int getCurrentExp = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.Experience).FirstOrDefault();
                getCurrentExp += expAmount;

                //find the user column in the database and modified the existing value
                var userData = db.Users.First(x => x.UserName == User.Identity.Name);
                userData.Experience = getCurrentExp;
                db.SaveChanges();
            }



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
                //remove the workoutexerise links associated with that random workout
                RemoveOldRandomWorkout(oldRandWorkout);
                //remove old random workouts
                db.Workouts.Remove(oldRandWorkout);
                db.SaveChanges();
            }

            //generate random workouts
            int newRanWorkoutId = GenRandomExercise(userBMI);


            //Creates the userWorkout table and passes it into "RandomCreate" to create the table
            UserWorkout userWorkout = new UserWorkout();
            RandomCreate(userWorkout, newRanWorkoutId);

            //Gets the UWId to redirect to correct id in "ConfirmWorkout" view
            int userId = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList().First();
            int uwid = repo.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.UWId).ToList().First();

            //start random workouts      
            return RedirectToAction("ConfirmWorkout", new { id = uwid });
        }

        /// <summary>
        /// Creates the random UserWorkout table when called in the Random function
        /// </summary>
        /// <param name="userWorkout"></param>
        /// <param name="uwid"></param>
        public void RandomCreate(UserWorkout userWorkout, int ranWorkoutId)
        {
            var currentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.First();

            userWorkout.UserId = userId;
            userWorkout.UserActiveWorkout = ranWorkoutId;
            userWorkout.ActiveWorkoutStage = 0;
            userWorkout.StartTime = DateTime.Now;
            db.UserWorkouts.Add(userWorkout);
            db.SaveChanges();
        }

        /// <summary>
        /// Used to remove the old links with the randomly generated workout
        /// </summary>
        /// <param name="oldRandomWorkout"></param>
        public void RemoveOldRandomWorkout(Workout oldRandomWorkout)
        {
            var links = db.WorkoutExercises.Where(x => x.WorkoutId == oldRandomWorkout.WorkoutId).Select(x => x).ToList();
            db.WorkoutExercises.RemoveRange(links);
            db.SaveChanges();
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


        /// <summary>
        /// Creates a workout NOT from plan (i.e., a "Free Workout")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Create(int? id)
        {
            //-1 is not a random workout id
            int RandWorkout = -1;

            //Random Workouts will have an id passed in where Free Workout will not, if random, the id is set here
            if (id != null)
            {
                RandWorkout = (int)id;
            }

            ViewBag.FromPlan = false;

            //gets the current user of the application
            var CurrentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.UserId = CurrentUser.UserId;

            ViewBag.UserActiveWorkout = new SelectList(repo.Workouts, "WorkoutId", "Name", RandWorkout);

            Workout workoutName = new Workout();
            ViewBag.PlannedWorkoutName = repo.Workouts.Where(x => x.WorkoutId == id).Select(x => x.Name).FirstOrDefault();

            return View();
        }

        // POST: UserWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UWId,UserId,UserActiveWorkout")] UserWorkout userWorkout)
        {
            var currentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.First();

            if (ModelState.IsValid)
            {
                //Checks to ensure there is not an active workout to prevent if the user were to go back in browser to "start" a second workout
                if (VerifyActiveWorkout() == false)
                {
                    userWorkout.ActiveWorkoutStage = 0;
                    userWorkout.FromPlan = false;
                    userWorkout.StartTime = DateTime.Now;
                    db.UserWorkouts.Add(userWorkout);
                    db.SaveChanges();
                    //gets the UWId for the routing id to track in progress workouts
                    var testuwid = repo.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.UWId).ToList();
                    int uwid = testuwid.First();

                    return RedirectToAction("ConfirmWorkout", routeValues: new { id = uwid});
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.UserId = new SelectList(repo.Users, "UserId", "UserName", userWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(repo.Workouts, "WorkoutId", "Name", userWorkout.UserActiveWorkout);
            return View(userWorkout);
        }

        /// <summary>
        /// Create page for planned workouts, passed in from the string in the Workout plans calendar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult CreatePlanWO(int id)
        {
            //Gets the passed in id from the Workout Plan calendar
            int WorkoutFromPlan = id;

            //gets the current user of the application
            var CurrentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.UserId = CurrentUser.UserId;

            ViewBag.UserActiveWorkout = new SelectList(repo.Workouts, "WorkoutId", "Name", WorkoutFromPlan);

            Workout workoutName = new Workout();
            ViewBag.PlannedWorkoutName = repo.Workouts.Where(x => x.WorkoutId == id).Select(x => x.Name).FirstOrDefault();

            return View();
        }

        // POST: UserWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlanWO([Bind(Include = "UWId,UserId,UserActiveWorkout")] UserWorkout userWorkout)
        {
            var currentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.First();

            if (ModelState.IsValid)
            {
                //Checks to ensure there is not an active workout to prevent if the user were to go back in browser to "start" a second workout
                if (VerifyActiveWorkout() == false)
                {
                    userWorkout.ActiveWorkoutStage = 0;
                    userWorkout.FromPlan = true;
                    db.UserWorkouts.Add(userWorkout);
                    db.SaveChanges();
                    //gets the UWId to be the routing id for ConfirmWorkouts page
                    var testuwid = repo.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.UWId).ToList();
                    int uwid = testuwid.First();

                    return RedirectToAction("ConfirmWorkout", routeValues: new { id = uwid});
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            ViewBag.UserId = new SelectList(repo.Users, "UserId", "UserName", userWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(repo.Workouts, "WorkoutId", "Name", userWorkout.UserActiveWorkout);
            return View(userWorkout);
        }

        /// <summary>
        /// Checks with the user if they want to confirm starting a workout, detailing rewards they can earn by doing so
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ConfirmWorkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //gets the activeWorkout record for the user
            var UserWorkout = db.UserWorkouts.Find(id);

            if (id != null)
            {
                int WorkoutById = (int)id;
            }

            WorkoutVM ConfirmStart = new WorkoutVM
            {
                UWId = UserWorkout.UWId,
                UserActiveWorkout = UserWorkout.UserActiveWorkout,
                WorkoutName = UserWorkout.Workout.Name,
                FromPlan = UserWorkout.FromPlan,
            };

            return View(ConfirmStart);
        }

        /// <summary>
        /// The view that handles loading the Progress page to move through exercises in a workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Progress(int? id)
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
                if (UserWorkout.FromPlan == true)
                {
                    PlanComplete = UpdatePlan();
                    return RedirectToAction("Complete", routeValues: new { id, planComplete = PlanComplete });
                }

                //go to completed screen and distribute rewards. Probably call the completed actionmethod here so it links in with Chi's exp code
                return RedirectToAction("Complete", routeValues: new { id });
            }
            else
            {
                //gets the current exercise in the workout by querying the workout/exercise transaction table. This iterates and returns all exercise except the first one everytime the next button is clicked
                Exercise ActiveExercise = db.WorkoutExercises.Where(x => x.WorkoutId == InProgressWorkout.WorkoutId && x.OrderNumber == UserWorkout.ActiveWorkoutStage + 1).Select(x => x.Exercise).First();
                //Get all subtables for the particular exercise's information
                ViewBag.Images = db.ExerciseImages.Where(x => x.ExerciseId == ActiveExercise.ExerciseId).ToList();
                ViewBag.Flags = db.ExerciseFlags.Where(x => x.ExerciseId == ActiveExercise.ExerciseId).ToList();
                ViewBag.Equipment = db.ExerciseEquipments.Where(x => x.ExerciseId == ActiveExercise.ExerciseId).ToList();

                //creates a view model that has the current exercise and the id for the currently active workout
                WorkoutVM CurrentExercise = new WorkoutVM
                {
                    CurrentExercise = ActiveExercise,
                    UWId = UserWorkout.UWId,
                    ActiveWorkoutStage = UserWorkout.ActiveWorkoutStage,
                    WorkoutName = UserWorkout.Workout.Name,
                    MaxWorkoutStage = maxStage,
                    UserActiveWorkout = UserWorkout.UserActiveWorkout,
                    FromPlan = UserWorkout.FromPlan
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
        public ActionResult ProgressForward(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserWorkout = db.UserWorkouts.Find(id);

            //changes the stage of the workout to the next exercise
            UserWorkout.ActiveWorkoutStage = StageMover(UserWorkout.ActiveWorkoutStage, 1);

            //saves the changes in the db
            db.Entry(UserWorkout).State = EntityState.Modified;
            db.SaveChanges();

            //returns to the progress function to reload the progress view
            return RedirectToAction("Progress", new { id = UserWorkout.UWId });
        }

        /// <summary>
        /// Used to move backward in a workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProgressBack(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var UserWorkout = db.UserWorkouts.Find(id);

            //changes the stage of the workout to the previous exercise
            UserWorkout.ActiveWorkoutStage = StageMover(UserWorkout.ActiveWorkoutStage, -1);

            //saves the changes in the db
            db.Entry(UserWorkout).State = EntityState.Modified;
            db.SaveChanges();

            //returns to the progress function to reload the progress view
            return RedirectToAction("Progress", new { id = UserWorkout.UWId });
        }

        /// <summary>
        /// Moves the ActiveWorkoutStage based on the incrementer passed in
        /// </summary>
        /// <param name="id"></param>
        /// <param name="incrementer"></param>
        /// <returns></returns>
        public int StageMover(int id, int incrementer)
        {
            return (id + incrementer);
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

            if (UserWorkout.FromPlan == true)
            {
                int WorkoutEventId = repo.WorkoutEvents.Where(x => x.WorkoutId == UserWorkout.UserActiveWorkout).Select(x => x.EventId).FirstOrDefault();
                RemoveUserWorkout(UserWorkout);
                return RedirectToAction("UpdateEvents", "Calendar", new { id = WorkoutEventId, abandon = true });
            }

            RemoveUserWorkout(UserWorkout);
            return RedirectToAction("Index");
        }


        /// <summary>
        /// Allows user to abandon a workout without a confirmation page, when called upon with a button
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QuickAbandon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            UserWorkout UserWorkout = db.UserWorkouts.Find(id);

            if (UserWorkout.FromPlan == true)
            {
                int WorkoutEventId = repo.WorkoutEvents.Where(x => x.WorkoutId == UserWorkout.UserActiveWorkout).Select(x => x.EventId).FirstOrDefault();
                db.UserWorkouts.Remove(UserWorkout);
                db.SaveChanges();
                return RedirectToAction("UpdateEvents", "Calendar", new { id = WorkoutEventId, abandon = true });
            }

            //deletes the specific workout in the db
            db.UserWorkouts.Remove(UserWorkout);
            db.SaveChanges();

            //returns to the index page
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

            bool CurrentUserFitbitLinked = repo.Users.Where(user => user.UserName == HttpContext.User.Identity.Name).Select(user => user.FitbitLinked).FirstOrDefault();

            if (UserWorkout == null)
            {
                return HttpNotFound();
            }
            //If the user completed their workout plan
            if (planComplete == true)
            {
                //get the current logged-in user Id
                int userId = repo.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();
                //Get the current users avatar unlocks
                var userUnlocks = db.AvatarUnlocks.Where(x => x.UserId == userId);
                //Get all available gear
                var allGear = db.Avatars.Where(x => x.Type == "Armor" || x.Type == "Weapon");
                bool foundGear = false;
                foreach(Avatar item in allGear)
                {
                    //Check if we already have gear
                    if(foundGear == false)
                    {
                        //check if the user has the current item in their unlocks
                        bool any = userUnlocks.Any(x => x.AvaId == item.AvaId);
                        if(any == false)
                        {
                            //Get our exit condtion filled
                            foundGear = true;
                            //Get the name of the gear to display on the HTML later
                            ViewBag.GotGear = item.Name;
                            //Add all gear with that name and type to the players unlocks
                            var addlist = db.Avatars.Where(x => x.Name == item.Name).Where(x => x.Type == item.Type).ToList();
                            foreach(Avatar add in addlist)
                            {
                                AvatarUnlock adder = new AvatarUnlock();
                                adder.UserId = userId;
                                adder.AvaId = add.AvaId;
                                db.AvatarUnlocks.Add(adder);
                                db.SaveChanges();
                            }
                        }
                    }
                }
                //If user has all gear in the game atm
                if (foundGear == false)
                {
                    //Tell the html code nothing was found and give the user 200 exp
                    ViewBag.GotGear = "none";
                    AddExp(200);
                }
                
                
            }


            if (planComplete != null)
            {
                ViewBag.PlanComplete = planComplete;
            }
            //sets a toggle for creating the option to record an event on fitbit website after completeing a powerlevel workout
            ViewBag.FitbitLinked = CurrentUserFitbitLinked;

            return View(UserWorkout);
        }

        /// <summary>
        /// Removes the userworkout record from db, should only be used if workout is abandoned
        /// </summary>
        /// <param name="userWorkout"></param>
        public void RemoveUserWorkout(UserWorkout userWorkout)
        {
            db.UserWorkouts.Remove(userWorkout);
            db.SaveChanges();
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

            //get current loggedin User ID
            var userId = db.Users.Where(x => x.UserName == User.Identity.Name).Select(y => y.UserId).FirstOrDefault();
            //increase their total workout completation count by 1
            User userObject = new User();
            userObject = db.Users.Find(userId);
            userObject.TotalWorkoutsCompleted += 1;


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
        public bool UpdatePlan()
        {
            //gets the active plan
            UserWorkoutPlan userPlan = db.UserWorkoutPlans.Where(x => x.UserName == HttpContext.User.Identity.Name).First();

            //updates the current stage of the plan
            userPlan.PlanStage = AdvanceStage(userPlan.PlanStage);

            //saves changes to the db
            db.Entry(userPlan).State = EntityState.Modified;
            db.SaveChanges();

            //checks if the plan has been completed
            if (IsPlanFinished(userPlan) == true)
            {
                FinishPlan(userPlan);
                return (true);
            }

            return (false);
        }


        /// <summary>
        /// Tests whether the workout plan has been finished or not.
        /// </summary>
        /// <param name="userPlan"></param>
        /// <returns></returns>
        public bool IsPlanFinished(UserWorkoutPlan userPlan)
        {
            if (userPlan.PlanStage == userPlan.MaxStage)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Used to advance the stage of a plan
        /// </summary>
        /// <param name="planStage"></param>
        /// <returns></returns>
        public int AdvanceStage(int planStage)
        {
            planStage += 1;
            return planStage;
        }

        /// <summary>
        /// Returns True if the logged in user has an active workout, else returns False
        /// </summary>
        /// <returns></returns>
        public bool VerifyActiveWorkout()
        {
            //Assume there is no active workout
            bool ActiveWorkout = false;

            var currentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.First();
            //Check db for active workouts of current user, if there is none then "ActiveWorkout" variable remains false
            var existingWorkoutCheck = repo.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.WorkoutCompleted).ToList().DefaultIfEmpty(true).First();
            if (existingWorkoutCheck == false)
            {
                ActiveWorkout = true;
            }
            return ActiveWorkout;
        }

        /// <summary>
        /// Removes WorkoutEvents from db after workout plan completetion
        /// </summary>
        public void RemoveWorkoutEvents()
        {
            //gets all of the associated workout events
            var Events = db.WorkoutEvents.Where(x => x.User.UserName == HttpContext.User.Identity.Name).Select(x => x);

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
