using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Giph.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public JsonResult Giph(string word)
        {
            //WebRequest
            System.Diagnostics.Debug.WriteLine(word);
            var data = new
            {
                message = word
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}