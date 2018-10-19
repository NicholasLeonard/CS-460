using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DistanceofColors.Controllers
{
    public class ColorController : Controller
    {
        // GET: Color
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string FirstColor, string SecondColor)
        {
            Debug.WriteLine(FirstColor);
            Debug.WriteLine(SecondColor);
            Color PrimaryColor = ColorTranslator.FromHtml(FirstColor);
            Color SecondaryColor = ColorTranslator.FromHtml(SecondColor);

            //R,B,G int componenets of mixing colors
            int PrimaryColorR = PrimaryColor.R;
            int PrimaryColorG = PrimaryColor.G;
            int PrimaryColorB = PrimaryColor.B;
            
            int SecondaryColorR = SecondaryColor.R;
            int SecondaryColorG = SecondaryColor.G;
            int SecondaryColorB = SecondaryColor.B;

            int MixedColorR = 0;
            int MixedColorG = 0;
            int MixedColorB = 0;
            
            //R,B,G int componenets of mixed color
            if(PrimaryColorR + SecondaryColorR < 255)
            {
                MixedColorR = PrimaryColorR + SecondaryColorR;
            }
            else
            {
               // int MixedColorR = 255;
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
            
            Color MixedColor = Color.FromArgb(MixedColorR, MixedColorG, MixedColorB);
            if(MixedColor.IsEmpty == false)
            {
                ViewBag.Mix = 100;
            }
            Debug.WriteLine(PrimaryColor);
            Debug.WriteLine(SecondaryColor);
            Debug.WriteLine(MixedColor.R);
            Debug.WriteLine(MixedColor.G);
            Debug.WriteLine(MixedColorB);
            

            string ResultColor = ColorTranslator.ToHtml(MixedColor);
            Debug.WriteLine(ResultColor);

            ViewBag.MixedColor = ResultColor;

            return View();
        }
    }
}