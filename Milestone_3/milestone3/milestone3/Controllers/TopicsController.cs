using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using milestone3.Models;

namespace milestone3.Controllers
{
    public class TopicsController : Controller
    {
        private ToasterItContext db = new ToasterItContext();

        // GET: Topics
        public ActionResult Index()
        {
            var topics = db.Topics.OrderByDescending(t => t.Timestamp);
            return View(topics.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
