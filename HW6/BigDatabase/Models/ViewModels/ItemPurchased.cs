using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigDatabase.Models.ViewModels
{
    public class ItemPurchased
    {
        public int StockItemID { get; set; }
        public string ItemDescription { get; set; }
        public decimal LineProfit { get; set; }
        public string SalesPerson { get; set; }
    }
}