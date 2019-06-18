using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Powerlevel.Controllers
{
    public class StyleController : Controller
    {//used to display the style guide page for picking colors, templates, designs, and fonts for the whole website
        // GET: Style
        public ActionResult StyleGuide()
        {
            return View();
        }
    }
}