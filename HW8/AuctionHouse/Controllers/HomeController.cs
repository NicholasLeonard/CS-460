using AuctionHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Microsoft.Ajax.Utilities;

namespace AuctionHouse.Controllers
{
    public class HomeController : Controller
    {
        AuctionContext db = new AuctionContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            var Items = db.Items;
            foreach (var item in Items)
            {
                Debug.WriteLine(item.Id);
                Debug.WriteLine(item.ItemName);
                Debug.WriteLine(item.Description);
                Debug.WriteLine(item.Seller);
            }    
                
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Disposes of connection to database
        /// </summary>
        /// <param name="disposing"></param>
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