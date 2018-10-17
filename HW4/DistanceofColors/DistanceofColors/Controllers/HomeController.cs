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
            string MileInput = Request.QueryString["Mile"];
            string units = Request.QueryString["Units"];

            if (MileInput != null)
            {//do a try catch here to handle query string input.
                double miles = Convert.ToDouble(MileInput);
                double result = 0;
                Debug.WriteLine(miles);
                Debug.WriteLine(units);
                
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

                string message = "The conversion is " + Convert.ToString(result);
                ViewBag.Conversion = message;
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