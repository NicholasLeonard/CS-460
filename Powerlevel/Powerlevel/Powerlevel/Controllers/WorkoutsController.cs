using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;

namespace Powerlevel.Models
{
    public class WorkoutsController : Controller
    {
        private toasterContext db = new toasterContext();

        public ActionResult Details(int? id)
        {
            /*if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }*/
                      
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        public ActionResult Index (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var test = db.Workouts.Include(y => y.WorkoutExercises);
            return View(test);
        }
    }
}
