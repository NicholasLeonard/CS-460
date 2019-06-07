using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;
using Powerlevel.Infastructure;

namespace Powerlevel.Controllers
{
    public class WorkoutPlanWorkoutController : Controller
    {
        private toasterContext db = new toasterContext();
        private IToasterRepository repo;

        public WorkoutPlanWorkoutController(IToasterRepository repository)
        {
            this.repo = repository;
        }

        /// <summary>
        /// Gets all of the workout plans available
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var planWorkouts = repo.WorkoutPlanWorkouts.Include(p => p.WorkoutPlan).Include(p => p.Workout);
            return View(planWorkouts.ToList());
        }
    }
}
