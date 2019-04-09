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
            // Sets the User that is creating a workout to the currently logged in User automatically
            var CurrentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.UserId = CurrentUser.UserId;

            /* These variables preset the selection of workouts to start so that the user starts at the beginning of a workout, not
             * somewhere in the middle.
             * The "Where" Statements in these two variables don't actually do anything, I just left them in there
             * in an effort to review and understand LINQ better later on
            */
            var WorkoutHellhole = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.Hellhole = WorkoutHellhole.LinkId;
            
            var WorkoutBurningBack = db.WorkoutExercises.Where(x => x.WorkoutId == 1).First();
            ViewBag.BurningBack = WorkoutBurningBack.LinkId + 3; /* Adding "+ 3" to the LinkId was the best method I could find
            in having the second "Burning Back" workout option start properly when selected by the user, can code this prettier later on */

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

            // Sets the User that is creating a workout to the currently logged in User automatically
            var CurrentUser = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            ViewBag.UserId = CurrentUser.UserId;

            //var WorkoutProgress = db.WorkoutExercises.Where(x => x.LinkId == id).First();
            //ViewBag.Progress = WorkoutProgress.LinkId + 1;

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

        // GET: UserCurrWorkouts/Abandon/5
        public ActionResult Abandon(int? id)
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

        // POST: UserCurrWorkouts/Abandon/5
        [HttpPost, ActionName("Abandon")]
        [ValidateAntiForgeryToken]
        public ActionResult AbandonConfirmed(int id)
        {
            UserCurrWorkout userCurrWorkout = db.UserCurrWorkouts.Find(id);
            db.UserCurrWorkouts.Remove(userCurrWorkout);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: UserCurrWorkouts/Complete/5
        public ActionResult Complete(int? id)
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

        // POST: UserCurrWorkouts/Complete/5
        [HttpPost, ActionName("Complete")]
        [ValidateAntiForgeryToken]
        public ActionResult CompleteConfirmed(int id)
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
