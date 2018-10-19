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
            string MileInput = Request.QueryString["Miles"];
            string units = Request.QueryString["Units"];

            
            if (MileInput != null)
            {
                double miles = 0;
                try
                {
                    miles = Convert.ToDouble(MileInput);
                }
                catch (FormatException)
                {
                    ViewBag.Error = "You created a format exception! Please enter the correct input.";
                    return View();
                }
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
                    default:
                        ViewBag.NoMetric = "You didn't select a proper metric measurment that I recognize! Check your spelling and capitalization.";
                        break;
                }
                if(ViewBag.NoMetric == null)
                {
                    string message = "The conversion is " + Convert.ToString(result) + " " + units;
                    ViewBag.Conversion = message;
                }
            }    
            
            return View();
        }
    }
}