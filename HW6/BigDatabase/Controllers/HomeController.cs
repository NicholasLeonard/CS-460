using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using BigDatabase.Controllers;
using BigDatabase.Models;
using BigDatabase.Models.ViewModels;

namespace BigDatabase.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult About()
        {


            List<PersonVM> SearchResult = db.People.Where(person => person.FullName.Contains("a")).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();
                
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}