using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Powerlevel.Models;


namespace Powerlevel.Controllers
{
    public class APIController : Controller
    {
        //Summary: API to get current logged-in user's infos
        //Note: Must NOT allow to accept any parameters
        public JsonResult GetUser()
        {
            //initialize database access
            toasterContext db = new toasterContext();

            //quick fixes to the circular reference error
            db.Configuration.ProxyCreationEnabled = false;

            //getting all the user's account infos by username
            var result = db.Users.Where(x => x.UserName == User.Identity.Name).ToList();

            //return the user result
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Summary: API to allow user to pass in parameters & get certain user's infos
        //Note: Parameters must NOT be NULL for strings inputs, so no '?' symbol
        public JsonResult Users(string id)
        {
            //initialize database access
            toasterContext db = new toasterContext();

            //quick fixes to the circular reference error
            db.Configuration.ProxyCreationEnabled = false;

            //getting all the user's account infos by username
            var result = db.Users.Where(x => x.UserName == id).ToList();

            //return the user result
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}