using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Powerlevel.Models;
using System.Threading;

namespace Powerlevel.Controllers
{
    public class CalendarController : Controller
    {//db access and reference day for scheduling workouts
        private toasterContext db = new toasterContext();
        private static DateTime today = DateTime.Now;
        private string currentUser = Thread.CurrentPrincipal.Identity.Name;

        //Used to display workout schedule to calendar
        public JsonResult Events(DateTime start, DateTime end)
        {
            //calls method to get all of the workout days for the plan
            List<Event> days = getWorkouts();
            
            //doesn't display anything if there is no active plan
            if(days == null)
            {
                return Json(days, JsonRequestBehavior.AllowGet); //Shouldn't display any events
            }

            //needs to be an array to display.
            var result = days.ToArray();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public List<Event> getWorkouts()
        {//event list to be returned to the calendar            
            List<Event> result = new List<Event>();

            //gets the plan id for the user, may need to change this if we allow multiple plans at a time
            var WorkoutPlanId = db.UserWorkoutPlans.Where(x => x.UserName == currentUser).Select(x => x.PlanId).ToList();
            
            //gets the users active plan, if there are no active plans then it is null and returns null to the caller
            var Workouts = db.WorkoutPlans.Find(WorkoutPlanId.FirstOrDefault());
            if(Workouts == null)
            {
                return null;
            }

            //gets the workouts in that active plan
            var AllWorkouts = Workouts.WorkoutPlanWorkouts.Where(x => x.PlanId == WorkoutPlanId.FirstOrDefault()).Select(x => new { x.Workout, x.DayOfPlan}).ToList();
            foreach(var item in AllWorkouts)
            {
                result.Add(new Event {
                    id = item.Workout.WorkoutId,
                    title = item.Workout.Name,
                    start = (item.DayOfPlan == 1) ? today : today.AddDays(2), //This is currently restricted to only having a 2 workout day plan
                    color = "red",
                    extra = "will this break event render?"
                });
            }

            return result;
        }
    }
}