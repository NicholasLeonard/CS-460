using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Powerlevel.Models;

namespace Powerlevel.Controllers
{
    public class CalendarController : Controller
    {
        private toasterContext db = new toasterContext();
        //Used to display workout schedule to calendar
        public JsonResult Events(DateTime start, DateTime end)
        {
            return Json(db.Events.Where(range => range.Start >= start).Select(x => new {
                id = x.EventId,
                title = x.Title,
                start = x.Start,
                end = x.End,
                color = x.StatusColor
            }).ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}