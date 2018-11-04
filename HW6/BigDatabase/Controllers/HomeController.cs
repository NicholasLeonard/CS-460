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
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();
       
        /// <summary>
        /// Action method that displays a searchbar and the results of the search for people in World Wide Importers database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            string client = Request.QueryString["client"];
            if (client != null && client != "" && client != " ")
            {
                List<PersonVM> SearchResult = db.People.Where(person => person.FullName.Contains(client)).Where(p => p.PersonID
                            != 1).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();

                if (SearchResult.FirstOrDefault() == null)
                {
                    ViewBag.Toggle = 2;
                    return View(SearchResult);
                }
                else
                {
                    ViewBag.Toggle = 1;
                    return View(SearchResult);
                }
            }
            else
            {
                return View();
            }
        }

        /// <summary>
        /// Action method for displaying specific details about a client or employee of World Wide Importers
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(string result)
        {//allows bigger queries to run without throwing a timeout exception
            db.Database.CommandTimeout = 300;
            if (result == null || result == "")
            {
                return (RedirectToAction("About"));
            }
            
            //Get's the default information for the details page.
            List<PersonVM> DetailPerson = db.People.Where(person => person.FullName == result).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();

            //Customer Company Details. See PersonVM.cs
            var CustomerDetails = db.People
                                    .Where(p => p.FullName == result)
                                    .Include("PrimaryContactPersonID")
                                    .SelectMany(p => p.Customers2).ToList();

            //Executes if CustomerDetails doesn't have any values.
            if (CustomerDetails.Count == 0)
            {// If the person is not a customer of World Wide Importers, return default details page.
                return View(DetailPerson);
            }
            else
            {
                //Items Purchased Details See PersonVM.cs. This query gets details on top 10 items sold to the customer.
                var ItemDetails = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                                    .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                    .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                    .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10).ToList();

                //A list of salesman for the top 10 items sold to the customer.
                var SalesMen = db.People.Where(person => person.FullName.Contains(result)).Include("PrimaryContactPersonID")
                                             .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                             .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                             .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10)
                                             .Include("InvoiceID").Select(x => x.Invoice).Include("SalespersonID").Select(x => x.Person4)
                                             .ToList();
                //Items Purchased Details see PersonVM.cs

                List<ItemPurchased> Top10Items = new List<ItemPurchased>();

                //Intializes a list of ItemPurchased classes that contains the details for the top 10 items sold to the customer.
                for (int i = 0; i < 10; i++)
                {//Initializes ItemPurchased for each of the 10 items
                    Top10Items.Add(new ItemPurchased
                    {
                        StockItemID = ItemDetails.ElementAt(i).StockItemID,
                        ItemDescription = ItemDetails.ElementAt(i).Description,
                        LineProfit = ItemDetails.ElementAt(i).LineProfit,
                        SalesPerson = SalesMen.ElementAt(i).FullName
                    });

                }
                //Creates a list of a PersonVM to be passed to the view that contains all of the necessary information
                List<PersonVM> Customers = new List<PersonVM>
                {
                    new PersonVM
                    {//Default Details See PersonVM.cs. Basic details about the person being searched.
                        Name = DetailPerson.First().Name,
                        PreferredName = DetailPerson.First().PreferredName,
                        PhoneNumber = DetailPerson.First().PhoneNumber,
                        FaxNumber = DetailPerson.First().FaxNumber,
                        EmailAddress = DetailPerson.First().EmailAddress,
                        ValidFrom = DetailPerson.First().ValidFrom,
                        //Customer Company Details; See PersonVM.cs. Details about the customer's company.
                        CompanyName = CustomerDetails.First().CustomerName,
                        CompanyPhone = CustomerDetails.First().PhoneNumber,
                        CompanyFax = CustomerDetails.First().FaxNumber,
                        CompanyWebsite = CustomerDetails.First().WebsiteURL,
                        CompanyValidFrom = CustomerDetails.First().ValidFrom,
                        //Purchase History Details; See PersonVM.cs. Total orders, GrossSales and Gross profit for those orders.
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
                        //Items purchased details. A list of details about the top 10 most profitable items sold to the customer. See ItemPurchased.cs
                        ItemPurchaseSummary = Top10Items
                    }
                };
                
                ViewBag.Toggle = 1;
                return View(Customers);
            }
        }

        

        /// <summary>
        /// Garbage collection method for disposing of database access when the controller has finished executing
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
