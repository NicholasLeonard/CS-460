using System.Diagnostics;
using System.Drawing;
using System.Web.Mvc;

namespace DistanceofColors.Controllers
{
    public class ColorController : Controller
    {
        /// <summary>
        /// Action method responsible for displaying default view from a GET request.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Action method for handling the mixing requirments for color selection from a POST request.
        /// </summary>
        /// <param name="FirstColor"></param>
        /// <param name="SecondColor"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(string FirstColor, string SecondColor)
        {//Console lines to make sure function is getting colors
            Debug.WriteLine(FirstColor);
            Debug.WriteLine(SecondColor);

            //Initializing new color objects that store ARGB values read in from a string containing the Hex number for 
            //the colors. These strings are coming from the HTML form.
            Color PrimaryColor = ColorTranslator.FromHtml(FirstColor);
            Color SecondaryColor = ColorTranslator.FromHtml(SecondColor);

            //R,B,G componenets of the first color from the form converted from its hex value into its integer values.
            int PrimaryColorR = PrimaryColor.R;
            int PrimaryColorG = PrimaryColor.G;
            int PrimaryColorB = PrimaryColor.B;
           
            //R,B,G componenets of the second color from the form converted from its hex value into its integer values.
            int SecondaryColorR = SecondaryColor.R;
            int SecondaryColorG = SecondaryColor.G;
            int SecondaryColorB = SecondaryColor.B;

            //R,B,G conponenets of the mixed color initialized to 0 but will later store the sum from the respective
            //components of the first and second colors.
            int MixedColorR = 0;
            int MixedColorG = 0;
            int MixedColorB = 0;
            
            //Setting the actual values of the R,G,B components of the mixed color from the two input colors.
            //Each component is capped at 255.
            if(PrimaryColorR + SecondaryColorR < 255)
            {
                MixedColorR = PrimaryColorR + SecondaryColorR;
            }
            else
            {
                MixedColorR = 255;
            }
            if(PrimaryColorG + SecondaryColorG < 255)
            {
                MixedColorG = PrimaryColorG + SecondaryColorG;
            }
            else
            {
                MixedColorG = 255;
            }
            if(PrimaryColorB + SecondaryColorB < 255)
            {
                MixedColorB = PrimaryColorB + SecondaryColorB;

            }
            else
            {
                MixedColorB = 255;
            }
            
            //Initializing new color object from the computed R,G,B components.
            Color MixedColor = Color.FromArgb(MixedColorR, MixedColorG, MixedColorB);

            //Used to initialize a viewbag to trigger display of the color cards on the webpage.
            if(MixedColor.IsEmpty == false)
            {//Number is insignificant as long as it is not null.
                ViewBag.Mix = 100;
            }
            
            //Console lines to confirm mixing if statement executed properly.
            Debug.WriteLine(PrimaryColor);
            Debug.WriteLine(SecondaryColor);
            Debug.WriteLine(MixedColor.R);
            Debug.WriteLine(MixedColor.G);
            Debug.WriteLine(MixedColorB);
            
            //Converting mixed color back into hex string from its Color object
            string ResultColor = ColorTranslator.ToHtml(MixedColor);

            //Console line to confirm resulting color.
            Debug.WriteLine(ResultColor);

            //Viewbags for passing all three hex string colors to the styling section of the webpage for displaying of
            //the color cards.
            ViewBag.FirstColor = FirstColor;
            ViewBag.SecondColor = SecondColor;
            ViewBag.MixedColor = ResultColor;

            return View();
        }
    }
}