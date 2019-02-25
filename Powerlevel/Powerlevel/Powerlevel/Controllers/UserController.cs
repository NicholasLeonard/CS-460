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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="Id, Height, Weight, UserName")] User currentUserMetrics)
        {//this gets the field for the current user that is entering their metrics
            if (ModelState.IsValid)
            {
                User metrics = db.Users.Find(currentUserMetrics.Id);
                db.Entry(metrics).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home", null);
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