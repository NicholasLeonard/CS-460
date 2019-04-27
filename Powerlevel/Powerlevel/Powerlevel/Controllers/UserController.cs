using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Diagnostics;
using System.Web.Mvc;
using System.Data.Entity;
using Powerlevel.Models;
using Powerlevel.Infastructure;

namespace Powerlevel.Controllers
{
    public class UserController : Controller
    {//for database access
        private toasterContext db = new toasterContext();
        private IToasterRepository repo;

        public UserController(IToasterRepository repository)
        {
            this.repo = repository;
        }

        /// <summary>
        /// Gets the current user and displays a page for them to enter height and weight
        /// </summary>
        /// <returns></returns>
        // GET: User
        public ActionResult Index()
        {
            User user = db.Users.Where(x => x.UserName == HttpContext.User.Identity.Name).FirstOrDefault();
            if(user == null)
            {
                return RedirectToAction("Index", "Home", null);
            }
            return View(user);
        }



        /// <summary>
        /// Used to adjust metrics after they have been entered
        /// </summary>
        /// <param name="currentUserMetrics"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserId, HeightFeet, HeightInch, Weight, UserName")] User currentUserMetrics)
        {//this gets the field for the current user that is entering their metrics
            if (ModelState.IsValid)
            {//gets the entry from the db
                User metrics = db.Users.Find(currentUserMetrics.UserId);
                //updates the values in the entry
                metrics.HeightFeet = currentUserMetrics.HeightFeet;

                if (currentUserMetrics.HeightInch > 9){// SAFETY CHECK
                    currentUserMetrics.HeightInch = 9; //currently if user set their inch > 10, BMI will get bug out. 
                }
                else { metrics.HeightInch = currentUserMetrics.HeightInch; }
                metrics.Weight = currentUserMetrics.Weight;
                //saves the changes to the db
                db.Entry(metrics).State = EntityState.Modified;


                //calculate user BMI on submit
                //BMI Formula: ( (lbs * 703) / inch^2 )
                //convert inch to decimal, then to inches
                double tempHeight = (double)(metrics.HeightFeet + (metrics.HeightInch / 10)) * 12;
                metrics.BMI = Math.Round((double)((metrics.Weight * 703) / Math.Pow(tempHeight, 2.00)), 2); //round to 2 decimal places
                db.SaveChanges();
            }
            // return RedirectToAction("Display", "User", null);
             return RedirectToAction("Index", "Manage", null);
        }

        /// <summary>
        /// Displays the current user's metrics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Display()
        {//gets the metrics of the current user
            var currentUser = HttpContext.User.Identity.Name;

            if(currentUser != null)
            {//displays the current user metrics
                User currentUserMetrics = db.Users.Where(x => x.UserName == currentUser).FirstOrDefault();
                return View(currentUserMetrics);
            }
            //if there is an error it displays on the account page with an error
            ManageController.ManageMessageId message = ManageController.ManageMessageId.Error;
            return RedirectToAction("Index", "Account", message);
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