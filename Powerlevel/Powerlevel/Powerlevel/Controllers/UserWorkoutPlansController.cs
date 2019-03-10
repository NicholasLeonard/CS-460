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

        // GET: UserWorkoutPlans
        //public ActionResult Index()
        //{
        //    return View(db.UserWorkoutPlans.ToList());
        //}

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

        // GET: UserWorkoutPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkoutPlan userWorkoutPlan = db.UserWorkoutPlans.Find(id);
            if (userWorkoutPlan == null)
            {
                return HttpNotFound();
            }
            return View(userWorkoutPlan);
        }

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
                // Create Database entry using given PlanId and Username and the entries in the WorkoutPlans table
                userWorkoutPlan.Name = db.WorkoutPlans.Where(x => x.PlanId == userWorkoutPlan.PlanId).First().Name;
                userWorkoutPlan.Type = db.WorkoutPlans.Where(x => x.PlanId == userWorkoutPlan.PlanId).First().Type;
                userWorkoutPlan.Description = db.WorkoutPlans.Where(x => x.PlanId == userWorkoutPlan.PlanId).First().Description;
                userWorkoutPlan.DaysToComplete = db.WorkoutPlans.Where(x => x.PlanId == userWorkoutPlan.PlanId).First().DaysToComplete;
                userWorkoutPlan.NumberOfWorkouts = db.WorkoutPlans.Where(x => x.PlanId == userWorkoutPlan.PlanId).First().NumberOfWorkouts;

                db.UserWorkoutPlans.Add(userWorkoutPlan);
                db.SaveChanges();         
                return RedirectToAction("Index");
            }
            return View(userWorkoutPlan);
        }

        // GET: UserWorkoutPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkoutPlan userWorkoutPlan = db.UserWorkoutPlans.Find(id);
            if (userWorkoutPlan == null)
            {
                return HttpNotFound();
            }
            return View(userWorkoutPlan);
        }

        // POST: UserWorkoutPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanId,UserName,Name,Type,Description,DaysToComplete,NumberOfWorkouts")] UserWorkoutPlan userWorkoutPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userWorkoutPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userWorkoutPlan);
        }

        // GET: UserWorkoutPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkoutPlan userWorkoutPlan = db.UserWorkoutPlans.Find(id);
            if (userWorkoutPlan == null)
            {
                return HttpNotFound();
            }
            return View(userWorkoutPlan);
        }

        // POST: UserWorkoutPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserWorkoutPlan userWorkoutPlan = db.UserWorkoutPlans.Find(id);
            db.UserWorkoutPlans.Remove(userWorkoutPlan);
            db.SaveChanges();
            return RedirectToAction("Index");
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
