using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Powerlevel.Models;
using Powerlevel.Infastructure;

namespace Powerlevel.Controllers
{
    public class CalendarController : Controller
    {//db access and repo access
        private IToasterRepository repo;
        
        private toasterContext db = new toasterContext();

        public CalendarController(IToasterRepository repository)
        {
            this.repo = repository;
        }

        /// <summary>
        /// Used to display workout schedule to calendar
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public JsonResult Events(DateTime start, DateTime end)
        {
            //list containing the events for the calendar
            List<Event> days = new List<Event>();

            //gets the workout events if there are any
            days = GetWorkouts();

            //needs to be an array to display.
            var result = days.ToArray();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Returns a list of Event Workouts to be displayed on the workout calendar
        /// </summary>
        /// <returns></returns>
        public List<Event> GetWorkouts()
        {
            //event list to be returned to the calendar            
            List<Event> result = new List<Event>();

            //gets all workout events to feed to the calendar
            List<WorkoutEvent> AllWorkoutEvents = repo.WorkoutEvents.Where(x => x.User.UserName == User.Identity.Name).Select(x => x).ToList();

            //if there are no workout events, then it sends empty list to calendar
            if(AllWorkoutEvents.Count == 0)
            {
                return result;
            }

            //creates calendar events off of the workouts for a plan
            foreach(var item in AllWorkoutEvents)
            {
                result.Add(new Event {
                    id = item.EventId, //sets a unique event id for fullcalendar to use
                    title = item.Title,
                    start = (DateTime)item.Start,
                    color = item.StatusColor,
                    description = item.Description,
                    url = EventUrl(item)
                });
            }

            return result;
        }

        /// <summary>
        /// Sets the url for the clickable calendar event
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public string EventUrl(WorkoutEvent item)
        {
            //if the status color is green meaning it has already been done, then make the url empty so you can't do it again and advance the plan
            //May need to change this when messing with abandon for a workout in a plan
            if(item.StatusColor == "green")
            {
                return "";
            }
            else
            {
                //Checks if the User already has an active workout, if so, they will not be given a link to the create page and will be advised to finish their current workout first
                var currentUser = repo.Users.Where(x => x.UserName == HttpContext.User.Identity.Name.ToString()).Select(x => x.UserId).ToList();
                int userId = currentUser.First();
                var existingWorkoutCheck = repo.UserWorkouts.Where(x => x.UserId == userId && x.WorkoutCompleted == false).Select(x => x.WorkoutCompleted).ToList().DefaultIfEmpty(true).First();
                if (existingWorkoutCheck == false)
                {
                    return ("");
                }

                return ("UserWorkouts/CreatePlanWO/" + item.WorkoutId);
            }
        }

        /// <summary>
        /// Determines the description message for a workout event
        /// </summary>
        /// <param name="completed"></param>
        /// <returns></returns>
        public string GetStateMessage(int completed)
        {
            string message;

            if(completed == 0)
            {
                message = "Not started";
            }
            else if(completed == 1)
            {
                message = "In progress";
            }
            else if(completed == 2)
            {
                message = "Completed";
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            return message;
        }

        /// <summary>
        /// Garbage collection method for disposing of database access when the controller has finished executing
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