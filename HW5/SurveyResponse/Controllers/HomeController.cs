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
    public class HomeController : Controller
    {
        private RequestContext db = new RequestContext();


        public ActionResult Index()
        {
            return View();
        }

        //method for submitting to database
        [HttpGet]
        public ActionResult Forms()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forms([Bind(Include="ID,FirstName,LastName,ApartmentName,UnitNumber,Phone,Comments,EnterForMaintenance,Submitted")] ServiceRequests serviceRequest)
        {
            if (ModelState.IsValid)
            {
                db.ServiceRequests.Add(serviceRequest);
                db.SaveChanges();
                return RedirectToAction("List");
            }

            return View(serviceRequest);
        }

        [HttpGet]
        public ActionResult List()
        {
            var list = db.ServiceRequests.ToList();
            var orderedlist = list.OrderBy(item => item.Submitted);
            return View(orderedlist);
        }

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