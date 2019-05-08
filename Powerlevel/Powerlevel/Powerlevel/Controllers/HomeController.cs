using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Powerlevel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Added this code to make sure the test is passing correctly
            return View("Index");
        }

        public ActionResult GettingStarted()
        {
            return View();
        }
    }
}