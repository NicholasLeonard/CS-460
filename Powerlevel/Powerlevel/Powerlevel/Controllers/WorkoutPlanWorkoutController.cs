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
<<<<<<< HEAD:Powerlevel/Powerlevel/Powerlevel/Controllers/PlanWorkoutsController.cs
            var workoutPlans = db.Plans.Include(x => x.WorkoutExercises);
            return View(workoutPlans);
=======
            var planWorkouts = db.WorkoutPlanWorkouts.Include(p => p.WorkoutPlan).Include(p => p.Workout);
            return View(planWorkouts.ToList());
>>>>>>> 72e0e573505120189e00032558cf9bc7517ff38e:Powerlevel/Powerlevel/Powerlevel/Controllers/WorkoutPlanWorkoutController.cs
        }
    }
}
