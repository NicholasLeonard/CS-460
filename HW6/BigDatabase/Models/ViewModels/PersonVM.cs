using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigDatabase.Models.ViewModels
{
    /// <summary>
    /// A class that holds all details about a client of World Wide Importers.
    /// </summary>
    public class PersonVM
    {//Default Details
        public string Name { get; set; }
        public string PreferredName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ValidFrom { get; set; }

        //Customer Company Details
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyWebsite { get; set; }
        public DateTime CompanyValidFrom { get; set; }

        //Purchase History Details
        public double Orders { get; set; }
        public decimal GrossSales { get; set; }
        public decimal GrossProfit { get; set; }
        
        //Items Purchased Details. See ItemPurchased.cs
        public List<ItemPurchased> ItemPurchaseSummary { get; set; }
    }
}