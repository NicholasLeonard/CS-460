using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionHouse.Models.ViewModels
{
    public class ItemVM
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string Seller { get; set; }

        //for displaying on the homepage
        public string Buyer { get; set; }
        public decimal BidAmount { get; set; }
        public string BidTime { get; set; }
    }
}