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
    public class UserCurrWorkoutsController : Controller
    {
        private toasterContext db = new toasterContext();

        // GET: UserCurrWorkouts
        public ActionResult Index()
        {
            var userCurrWorkouts = db.UserCurrWorkouts.Include(u => u.User).Include(u => u.WorkoutExercise);
            return View(userCurrWorkouts.ToList());
        }

        // GET: UserCurrWorkouts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCurrWorkout userCurrWorkout = db.UserCurrWorkouts.Find(id);
            if (userCurrWorkout == null)
            {
                return HttpNotFound();
            }
            return View(userCurrWorkout);
        }

        // GET: UserCurrWorkouts/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            ViewBag.UserActiveWorkout = new SelectList(db.WorkoutExercises, "LinkId", "LinkId");
            return View();
        }

        // POST: UserCurrWorkouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UCWId,UserId,UserActiveWorkout")] UserCurrWorkout userCurrWorkout)
        {
            if (ModelState.IsValid)
            {
                db.UserCurrWorkouts.Add(userCurrWorkout);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", userCurrWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(db.WorkoutExercises, "LinkId", "LinkId", userCurrWorkout.UserActiveWorkout);
            return View(userCurrWorkout);
        }

        // GET: UserCurrWorkouts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCurrWorkout userCurrWorkout = db.UserCurrWorkouts.Find(id);
            if (userCurrWorkout == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", userCurrWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(db.WorkoutExercises, "LinkId", "LinkId", userCurrWorkout.UserActiveWorkout);
            return View(userCurrWorkout);
        }

        // POST: UserCurrWorkouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UCWId,UserId,UserActiveWorkout")] UserCurrWorkout userCurrWorkout)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userCurrWorkout).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", userCurrWorkout.UserId);
            ViewBag.UserActiveWorkout = new SelectList(db.WorkoutExercises, "LinkId", "LinkId", userCurrWorkout.UserActiveWorkout);
            return View(userCurrWorkout);
        }

        // GET: UserCurrWorkouts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserCurrWorkout userCurrWorkout = db.UserCurrWorkouts.Find(id);
            if (userCurrWorkout == null)
            {
                return HttpNotFound();
            }
            return View(userCurrWorkout);
        }

        // POST: UserCurrWorkouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserCurrWorkout userCurrWorkout = db.UserCurrWorkouts.Find(id);
            db.UserCurrWorkouts.Remove(userCurrWorkout);
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
