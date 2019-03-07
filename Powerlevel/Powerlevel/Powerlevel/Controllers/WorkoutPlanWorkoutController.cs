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
    public class WorkoutPlanWorkoutController : Controller
    {
        private toasterContext db = new toasterContext();

        // GET: PlanWorkouts
        public ActionResult Index()
        {
            var planWorkouts = db.WorkoutPlanWorkouts.Include(p => p.WorkoutPlan).Include(p => p.Workout);
            return View(planWorkouts.ToList());
        }
    }
}
