using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;
using Powerlevel.Infastructure;

namespace Powerlevel.Controllers
{
    public class UserWorkoutPlansController : Controller
    {
        //db access
        private toasterContext db = new toasterContext();
        private IToasterRepository repo;

        public UserWorkoutPlansController(IToasterRepository repository)
        {
            this.repo = repository;
        }

        //used for making workout events for calendar workout plans
        private static DateTime today = DateTime.Now;

        //GET: UserWorkoutPlans
        public ActionResult Index()
        {
            ViewBag.WorkoutInProgress = false;
            var currentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
            int userId = currentUser.FirstOrDefault();
            var existingWorkoutCheck = repo.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.WorkoutCompleted).ToList().DefaultIfEmpty(true).First();
            if (existingWorkoutCheck == false)
            {
                ViewBag.WorkoutInProgress = true;
            }

            ViewBag.Workoutplans = repo.WorkoutPlans.ToList();
            return View(repo.UserWorkoutPlans.ToList());
        }

        // GET: UserWorkoutPlans/Create
        public ActionResult Create()
        {
            //get the list of plans from the db and pass into the viewbag
            ViewBag.AvailablePlans = new SelectList(repo.WorkoutPlans, "PlanId", "Name");

            return View();
        }

        // POST: UserWorkoutPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanId,UserName,PlanStage")] UserWorkoutPlan userWorkoutPlan)
        {
            if (ModelState.IsValid)
            {
                //Prevents the user from starting a second plan if they have an existing one
                if (VerifyActivePlan() == false)
                {
                    userWorkoutPlan.MaxStage = repo.WorkoutPlanWorkouts.Where(x => x.PlanId == userWorkoutPlan.PlanId).Count();
                    db.UserWorkoutPlans.Add(userWorkoutPlan);
                    db.SaveChanges();

                    //calls a method to add all workouts in plan to workoutEvents table
                    AddWorkoutEvents(userWorkoutPlan.PlanId);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View(userWorkoutPlan);
        }

        [HttpGet]
        public ActionResult Abandon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkoutPlan ActiveUserPlan = db.UserWorkoutPlans.Find(id);
            if (ActiveUserPlan == null)
            {
                return HttpNotFound();
            }
            return View(ActiveUserPlan);
        }

        // POST: UserWorkouts/Abandon/5
        [HttpPost, ActionName("Abandon")]
        [ValidateAntiForgeryToken]
        public ActionResult AbandonConfirmed(int id)
        {
            UserWorkoutPlan UserWorkoutPlan = db.UserWorkoutPlans.Find(id);
            db.UserWorkoutPlans.Remove(UserWorkoutPlan);
            db.SaveChanges();

            //deletes workout events associated with the plan
            var WorkoutEvents = db.WorkoutEvents.Where(x => x.User.UserName == HttpContext.User.Identity.Name).Select(x => x);
            db.WorkoutEvents.RemoveRange(WorkoutEvents);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Adds workoutEvents to the db for event persistence
        /// </summary>
        /// <param name="planId"></param>
        public void AddWorkoutEvents(int planId)
        {
            //list of workouts to be added to the events table to feed the calendar
            List<WorkoutEvent> Events = new List<WorkoutEvent>();

            //gets the userId of the current user so we can link it in the workout event table
            int user = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).Select(x => x.UserId).ToArray().First();

            //gets the workout plan that the user is doing
            var Workouts = db.WorkoutPlans.Find(planId);

            //gets all of the workouts in the workout plan
            var AllWorkouts = Workouts.WorkoutPlanWorkouts.Where(x => x.PlanId == planId).Select(x => new { x.Workout, x.DayOfPlan }).ToList();

            //adds each workout as a workout event to be added to the events table in db
            foreach (var item in AllWorkouts)
            {
                Events.Add(new WorkoutEvent
                {
                    Title = item.Workout.Name,
                    Start = (item.DayOfPlan == 1) ? today : Events.First().Start.Value.AddDays(item.DayOfPlan - 1), //this is determining the day on calendar for workout based on day of plan and the first workout in the plan
                    StatusColor = "red",
                    UserId = user,
                    WorkoutId = item.Workout.WorkoutId,
                    Description = ""
                });
            }

            //adds records to the db assuming that the events list is valid
            if (Events != null)
            {
                db.WorkoutEvents.AddRange(Events);
                db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Returns True if the logged in user has an active plan, else returns False
        /// </summary>
        /// <returns></returns>
        public bool VerifyActivePlan()
        {
            //Assume there is no active plan
            bool ActivePlan = false;

            var currentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserName).ToList();
            string userName = currentUser.First();
            //Check db for active workouts of current user, if there is none then "ActiveWorkout" variable remains false
            var existingPlanCheck = repo.UserWorkoutPlans.Where(x => x.UserName == userName).Select(x => x.PlanId).ToList().DefaultIfEmpty(0).First();
            if (existingPlanCheck != 0)
            {
                ActivePlan = true;
            }
            return ActivePlan;
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
