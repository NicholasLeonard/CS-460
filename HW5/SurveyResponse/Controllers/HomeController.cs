using SurveyResponse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SurveyResponse.DAL;


namespace SurveyResponse.Controllers
{
    /// <summary>
    /// Controller for all pages
    /// </summary>
    public class HomeController : Controller
    {//instance of the database
        private RequestContext db = new RequestContext();

        /// <summary>
        /// Displays main landing page for Mountain View Apartments
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///Action method displays default form page to be filled and submitted to the database.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Forms()
        {
            return View();
        }

        /// <summary>
        /// Action method for submitting to the database
        /// </summary>
        /// <param name="serviceRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forms([Bind(Include="ID,FirstName,LastName,ApartmentName,UnitNumber,Phone,Comments,EnterForMaintenance,Submitted")] ServiceRequests serviceRequest)
        {//first confirms that form submission is valid
            if (ModelState.IsValid)
            {//stages additions to database. Next line commits the changes to the database
                db.ServiceRequests.Add(serviceRequest);
                db.SaveChanges();
                //Redirects to the list page that displays the updated table in the database
                return RedirectToAction("List");
            }
            //if the submit is invalid, it returns the default form view
            return View(serviceRequest);
        }

        /// <summary>
        /// Action method for displaying the degault list page
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {//initializes list variable with table from the database, intializes orderedlist variable with sorted list variable
            var list = db.ServiceRequests.ToList();
            var orderedlist = list.OrderBy(item => item.Submitted);
            //returns sorted list rather than by table order
            return View(orderedlist);
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