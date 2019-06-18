using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigDatabase.Models.ViewModels
{
    /// <summary>
    /// A class that contains details about top 10 items sold to a customer.
    /// </summary>
    public class ItemPurchased
    {
        public int StockItemID { get; set; }
        public string ItemDescription { get; set; }
        public decimal LineProfit { get; set; }
        public string SalesPerson { get; set; }
    }
}