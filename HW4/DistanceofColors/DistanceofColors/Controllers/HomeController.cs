using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistanceofColors.Controllers
{/// <summary>
/// Controller for the home page and the converter page.
/// </summary>
    public class HomeController : Controller
    {/// <summary>
    /// Action method for displaying the home landing page.
    /// </summary>
    /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET action method for displaying the converter page as well as handling the computation and updating the page with the result of the conversion.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Converter()
        {//Local variables that contain the results of the query strings from the page.
            string MileInput = Request.QueryString["Miles"];
            string Units = Request.QueryString["Units"];

            //Confirms that input was actually read, otherwise it just displays the default page.
            if (MileInput != null)
            {
                double miles = 0;

                //Handles format errors from the query string for the mile attribute.
                try
                {
                    miles = Convert.ToDouble(MileInput);
                }
                catch (FormatException)
                {//Custom error message is passed to the view and the view is displayed.
                    ViewBag.Error = "You created a format exception! Please enter the correct input.";
                    return View();
                }

                //Variable to contain the result of the conversion.
                double result = 0;

                //Console writes to confirm input from query strings
                Debug.WriteLine(miles);
                Debug.WriteLine(Units);
                
                //Switch used to determine which conversion to perform.
                switch (Units)
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
                        //Custom error message to handle format errors in the Units query string.
                        ViewBag.NoMetric = "You didn't select a proper metric measurment that I recognize! Check your spelling and capitalization.";
                        break;
                }
                //Executes if the switch statement completed with no format errors.
                if(ViewBag.NoMetric == null)
                {//Converts the result to a string and puts it in a ViewBag to be passed back to the view.
                    string Message = "The conversion is " + Convert.ToString(result) + " " + Units;
                    ViewBag.Conversion = Message;
                }
            }    
            
            return View();
        }
    }
}