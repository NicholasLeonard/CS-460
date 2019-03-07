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
    public class UserWorkoutsController : Controller
    {
        private toasterContext db = new toasterContext();

        // GET: UserWorkouts
        public ActionResult Index()
        {
            var userWorkouts = db.UserWorkouts.Include(u => u.User);
            return View(userWorkouts);
        }

        // GET: UserWorkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            if (userWorkout == null)
            {
                return HttpNotFound();
            }
            return View(userWorkout);
        }

        // GET: UserWorkouts/Create
        public ActionResult Create()
        {
            ViewBag.UsernameId = new SelectList(db.Users, "Id", "UserName");
            ViewBag.UserCurrentPlan = new SelectList(db.WorkoutExercises, "LinkID", "PlanId");
            return View();
        }

        // POST: UserWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UWId,UsernameId,UserCurrentPlan")] UserWorkout userWorkout)
        {
            if (ModelState.IsValid)
            {
                db.UserWorkouts.Add(userWorkout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsernameId = new SelectList(db.Users, "Id", "UserName", userWorkout.UsernameId);

            // I messed around with this a little bit, I wanted to make the dropdown show the name of the workout plan, instead of a number
            // See: Notes in the UserWorkouts/Create View. (I failed, it is incomplete)
            ViewBag.UserCurrentPlan = new SelectList(db.WorkoutExercises, "LinkID", "PlanId", userWorkout.UserCurrentPlan); //new SelectList(db.PlanWorkout, "LinkID", "PlanId", userWorkout.UserCurrentPlan);
            return View(userWorkout);
        }

        // GET: UserWorkouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            if (userWorkout == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsernameId = new SelectList(db.Users, "Id", "Email", userWorkout.UsernameId);
            ViewBag.UserCurrentPlan = new SelectList(db.WorkoutExercises, "LinkID", "LinkID", userWorkout.UserCurrentPlan);
            return View(userWorkout);
        }

        // POST: UserWorkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UWId,UsernameId,UserCurrentPlan")] UserWorkout userWorkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userWorkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsernameId = new SelectList(db.Users, "Id", "Email", userWorkout.UsernameId);
            ViewBag.UserCurrentPlan = new SelectList(db.WorkoutExercises, "LinkID", "LinkID", userWorkout.UserCurrentPlan);
            return View(userWorkout);
        }

        // Just the delete scaffold renamed for "Completing"
        // GET: UserWorkouts/Complete/5
        public ActionResult Complete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            if (userWorkout == null)
            {
                return HttpNotFound();
            }
            return View(userWorkout);
        }

        // POST: UserWorkouts/Complete/5
        [HttpPost, ActionName("Complete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            db.UserWorkouts.Remove(userWorkout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Just the delete scaffold renamed for "Abandoning"
        // GET: UserWorkouts/Abandon/5
        public ActionResult Abandon(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            if (userWorkout == null)
            {
                return HttpNotFound();
            }
            return View(userWorkout);
        }

        // POST: UserWorkouts/Abandon/5
        [HttpPost, ActionName("Abandon")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed2(int id)
        {
            UserWorkout userWorkout = db.UserWorkouts.Find(id);
            db.UserWorkouts.Remove(userWorkout);
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
