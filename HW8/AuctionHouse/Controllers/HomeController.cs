using AuctionHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Microsoft.Ajax.Utilities;
using AuctionHouse.Models.ViewModels;

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
        {//gets all of the items from the database
            var Items = db.Items;
            //a new list of item view models for displaying in the view
            List<ItemVM> ItemList = new List<ItemVM>();
            //populates the list
            foreach (var item in Items)
            {
                ItemList.Add(new ItemVM { Id = item.Id, Description = item.Description, ItemName = item.ItemName, Seller = item.Seller });
            }    
                
            return View(ItemList);
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