using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Diagnostics;
using System.Web.Mvc;
using System.Data.Entity;
using Powerlevel.Models;

namespace Powerlevel.Controllers
{
    public class UserController : Controller
    {//for database access
        private toasterContext db = new toasterContext();

        /// <summary>
        /// Gets the current user and displays a page for them to enter height and weight
        /// </summary>
        /// <returns></returns>
        // GET: User
        public ActionResult Index()
        {
            var currentUser = Thread.CurrentPrincipal.Identity.Name;
            User user = db.Users.Where(x => x.UserName == currentUser).FirstOrDefault();
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
        public ActionResult Index([Bind(Include ="Id, Height, Weight, UserName")] User currentUserMetrics)
        {//this gets the field for the current user that is entering their metrics
            if (ModelState.IsValid)
            {//gets the entry from the db
                User metrics = db.Users.Find(currentUserMetrics.UserId);
                //updates the values in the entry
                metrics.Height = currentUserMetrics.Height;
                metrics.Weight = currentUserMetrics.Weight;
                //saves the changes to the db
                db.Entry(metrics).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Display", "User", null);
        }

        /// <summary>
        /// Displays the current user's metrics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Display()
        {//gets the metrics of the current user
            var currentUser = Thread.CurrentPrincipal.Identity.Name;

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