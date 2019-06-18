using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionHouse.Models.ViewModels
{
    public class BidVM
    {
        public string Buyer { get; set; }
        public decimal Price { get; set; }
    }
}