using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuctionHouse.Models;

namespace AuctionHouse.Controllers
{
    public class BidsController : Controller
    {
        private AuctionContext db = new AuctionContext();

        // GET: Bids
        public ActionResult Index()
        {
            var bids = db.Bids.Include(b => b.Buyer1).Include(b => b.Item1);
            return View(bids.ToList());
        }

        // GET: Bids/Create
        public ActionResult Create()
        {
            ViewBag.Buyer = new SelectList(db.Buyers, "BuyerId", "BuyerName");
            ViewBag.Item = new SelectList(db.Items, "ItemId", "ItemName");
            return View();
        }

        // POST: Bids/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidId,Item,Buyer,Price")] Bid bid)
        {
            if (ModelState.IsValid)
            {
                bid.TimeStamp = DateTime.Now;
                db.Bids.Add(bid);
                db.SaveChanges();
                return RedirectToAction("List", "Home", null);
            }

            ViewBag.Buyer = new SelectList(db.Buyers, "BuyerId", "BuyerName", bid.Buyer);
            ViewBag.Item = new SelectList(db.Items, "ItemId", "ItemName", bid.Item);
            return View(bid);
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
