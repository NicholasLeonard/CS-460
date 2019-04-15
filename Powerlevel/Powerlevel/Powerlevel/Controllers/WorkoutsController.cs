﻿using System;
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                      
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return HttpNotFound();
            }
            return View(workout);
        }

        /*This code actually displays all of the workouts in a workoutplan with a given id (confusing, but okay)
         * We take in the parameter of id to determine what workouts to grab
         * We also take a viewbag for the description of the plan given that id
         */
        public ActionResult Index (int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Store the description to be displayed for the given workoutplan
            ViewBag.Description = db.WorkoutPlans.Where(x => x.PlanId == id).First().Description;
            var test = db.WorkoutPlanWorkouts.Where(x => x.PlanId == id).Include(x => x.Workout);
            return View(test);
        }
    }
}
