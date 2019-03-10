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
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "plan_type" : "";
            var UserWorkoutPlan = from s in db.UserWorkoutPlans
                           select s;
            switch (sortOrder)
            {
                case "plan_type":
                    UserWorkoutPlan = UserWorkoutPlan.OrderByDescending(s => s.Type);
                    break;
                //case "Date":
                //    UserWorkoutPlan = UserWorkoutPlan.OrderBy(s => s.Name);
                //    break;
                //case "date_desc":
                //    UserWorkoutPlan = UserWorkoutPlan.OrderByDescending(s => s.Type);
                //    break;
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
