using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;

namespace Powerlevel.Controllers
{
    public class UserWorkoutPlansController : Controller
    {
        private toasterContext db = new toasterContext();

        //GET: UserWorkoutPlans
        public ActionResult Index()
        {
            ViewBag.Workoutplans = db.WorkoutPlans.ToList();
            return View(db.UserWorkoutPlans.ToList());
        }

        //REFACTOR:: Leaving this in for now incase I want to try and implement it again later, does not work with the current model
        /*
        public ActionResult Index(string sortOrder)
        {
            //sorting function
            ViewBag.UserNameSortParm = String.IsNullOrEmpty(sortOrder) ? "username" : "";
            ViewBag.PlanNameSortParm = String.IsNullOrEmpty(sortOrder) ? "plan_name" : "";
            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "plan_type" : "";
            ViewBag.DescriptionSortParm = String.IsNullOrEmpty(sortOrder) ? "description" : "";
            ViewBag.DaysSortParm = String.IsNullOrEmpty(sortOrder) ? "days" : "";
            ViewBag.NumWorkoutsSortParm = String.IsNullOrEmpty(sortOrder) ? "numWorkouts" : "";
            var UserWorkoutPlan = from s in db.UserWorkoutPlans
                           select s;
            switch (sortOrder)
            {
                case "username":
                    UserWorkoutPlan = UserWorkoutPlan.OrderBy(s => s.UserName);
                    break;
                case "plan_name":
                    UserWorkoutPlan = UserWorkoutPlan.OrderBy(s => s.Name);
                    break;
                case "plan_type":
                    UserWorkoutPlan = UserWorkoutPlan.OrderBy(s => s.Type);
                    break;
                case "description":
                    UserWorkoutPlan = UserWorkoutPlan.OrderBy(s => s.Description);
                    break;
                case "days":
                  UserWorkoutPlan = UserWorkoutPlan.OrderBy(s => s.DaysToComplete);
                  break;
                case "numWorkouts":
                    UserWorkoutPlan = UserWorkoutPlan.OrderBy(s => s.NumberOfWorkouts);
                    break;
                default:
                    UserWorkoutPlan = UserWorkoutPlan.OrderBy(s => s.UserName);
                    break;
            }
            return View(UserWorkoutPlan.ToList());  
        }
        */

        // GET: UserWorkoutPlans/Create
        public ActionResult Create()
        {
            //ViewBag.AvailablePlans = new SelectList(db.WorkoutPlanWorkouts, "WorkoutID", "WorkoutID");


            //get the list of plans from the db and pass into the viewbag
            ViewBag.AvailablePlans = new SelectList(db.WorkoutPlans, "PlanId", "Name");

            return View();
        }

        // POST: UserWorkoutPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanId,UserName")] UserWorkoutPlan userWorkoutPlan)
        {
            if (ModelState.IsValid)
            {

                db.UserWorkoutPlans.Add(userWorkoutPlan);
                db.SaveChanges();         
                return RedirectToAction("Index");
            }
            return View(userWorkoutPlan);
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
