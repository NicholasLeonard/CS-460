using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistanceofColors.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            double miles = Convert.ToDouble(Request.QueryString["Mile"]);
            string units = Request.QueryString["Units"];
            Debug.WriteLine(miles);
            Debug.WriteLine(units);
            double result;
            switch (units)
            {
                case "Millimeters":
                    result = miles * 1609344;
                    break;
                case "Centimeters":
                    result = miles * 160934.4;
                    break;
                case "Meters":
                    result = miles * 1609.344;
                    break;
                case "Kilometers":
                    result = miles * 1.609344;
                    break;
            }
            
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}