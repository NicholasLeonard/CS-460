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
    public class ExerciseController : Controller
    {
        private toasterContext db = new toasterContext();

        /// <summary>
        /// Displays all exercises
        /// </summary>
        /// <returns>View with list of all exercises and Viewbag with All equipment for exercises</returns>
        // GET: Exercise
        public ActionResult Index()
        {
            //Grab all equipment to be displayed
            ViewBag.Equipment = db.ExerciseEquipments.ToList();
            return View(db.Exercises.ToList());
        }

        /// <summary>
        /// Displays the details of a particular exercise
        /// </summary>
        /// <param name="id">id in the exercise table of the particualr exercise</param>
        /// <returns>exercise object</returns>
        // GET: Exercise/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Get all subtables for the particular exercise's information
            Exercise exercise = db.Exercises.Find(id);
            ViewBag.Images = db.ExerciseImages.Where(x => x.ExerciseId == exercise.ExerciseId).ToList();
            ViewBag.Flags = db.ExerciseFlags.Where(x => x.ExerciseId == exercise.ExerciseId).ToList();
            ViewBag.Equipment = db.ExerciseEquipments.Where(x => x.ExerciseId == exercise.ExerciseId).ToList();

            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        /// <summary>
        /// Returns a list of Exercises within a specific workout
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult WorkoutList(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var exercises = db.WorkoutExercises.Where(x => x.WorkoutId == id).Include(x => x.Exercise).OrderBy(x => x.OrderNumber);
            if(exercises != null)
            {
                return View(exercises);
            }//returns bad status code if nothing was found in the db
            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Disposes of db instance
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
