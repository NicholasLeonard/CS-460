using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;
using Powerlevel.Models.ViewModels;

namespace Powerlevel.Models
{
    public class TestingController : Controller
    {
        // GET: Testing
        public ActionResult Index()
        {
            return View();
        }
    }
}