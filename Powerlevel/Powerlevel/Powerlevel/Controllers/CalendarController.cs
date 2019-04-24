using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Powerlevel.Models;
using System.Threading;
using Powerlevel.Infastructure;
using Ninject;


namespace Powerlevel.Controllers
{
    public class CalendarController : Controller
    {//db access and current user 
        private IToasterRepository db;
        private string currentUser = Thread.CurrentPrincipal.Identity.Name;

        public CalendarController(IToasterRepository repository)
        {
            this.db = repository;
        }

        //Used to display workout schedule to calendar
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
            List<WorkoutEvent> AllWorkoutEvents = db.WorkoutEvents.Where(x => x.User.UserName == currentUser).Select(x => x).ToList();

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
                    url = "UserWorkouts/Create/" + item.WorkoutId
                });
            }

            return result;
        }

        //used to determine the progress of a workout
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
        /// Used to update information about the workout events and make it persistent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult UpdateEvents(int id)
        {
            //gets the WorkoutEvent that needs to be modified
            WorkoutEvent CurrentEvent = db.WorkoutEvents.Find(id);

            //updates the workoutevent
            CurrentEvent.StatusColor = "green";
            CurrentEvent.Description = GetStateMessage(2);

            //saves changes to the db
            db.Update(CurrentEvent);
            
            return null;
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