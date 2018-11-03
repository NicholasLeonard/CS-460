using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using BigDatabase.Controllers;
using BigDatabase.Models;
using BigDatabase.Models.ViewModels;
using System.Web.Security;
using System.Data.Entity;

namespace BigDatabase.Controllers
{
    public class SalesController : Controller
    {
         UserContext db = new UserContext();

        [HttpGet]
        public ActionResult Details(string result)
        {
            if (result == null || result == "")
            {
                return (RedirectToAction("About"));
            }

            Debug.WriteLine(result);
            List<PersonVM> DetailPerson = db.People
                .Where(person => person.FullName == result)
                .Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();

            //Customer Company Details
            var CustomerDetails = db.People
                                    .Where(p => p.FullName == result)
                                    .Include("PrimaryContactPersonID")
                                    .SelectMany(p => p.Customers2).ToList();
            //Items Purchased Details
            var ItemDetails = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                                .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10).ToList();

            var SalesMen = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                             .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders).Include("OrderID")
                             .Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                             .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10)
                             .Include("InvoiceID").Select(x => x.Invoice).Include("SalespersonID").Select(x => x.Person4)
                             .ToList();
            //Items Purchased Details

            List<ItemPurchased> Top10Items = new List<ItemPurchased>();
            
            for (int i = 0; i < 10; i++)
            {
                Top10Items.Add(new ItemPurchased
                {
                    StockItemID = ItemDetails.ElementAt(i).StockItemID,
                    ItemDescription = ItemDetails.ElementAt(i).Description,
                    LineProfit = ItemDetails.ElementAt(i).LineProfit,
                    SalesPerson = SalesMen.ElementAt(i).FullName
                });
                
            }




            PersonVM Customer = new PersonVM
            {//Default Details
                Name = DetailPerson.First().Name,
                PreferredName = DetailPerson.First().PreferredName,
                PhoneNumber = DetailPerson.First().PhoneNumber,
                FaxNumber = DetailPerson.First().FaxNumber,
                EmailAddress = DetailPerson.First().EmailAddress,
                ValidFrom = DetailPerson.First().ValidFrom,
                //Customer Company Details
                CompanyName = CustomerDetails.First().CustomerName,
                CompanyPhone = CustomerDetails.First().PhoneNumber,
                CompanyFax = CustomerDetails.First().FaxNumber,
                CompanyWebsite = CustomerDetails.First().WebsiteURL,
                CompanyValidFrom = CustomerDetails.First().ValidFrom,
                //Purchase History Details
                Orders = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                           .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders).Count(),

                GrossSales = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                               .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                               .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices)
                               .Include("InvoiceID").SelectMany(x => x.InvoiceLines).Sum(x => x.ExtendedPrice),

                GrossProfit = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                               .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                               .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices)
                               .Include("InvoiceID").SelectMany(x => x.InvoiceLines).Sum(x => x.LineProfit),
                ItemPurchaseSummary = Top10Items
            };
            return View(DetailPerson);
        }
    }
}