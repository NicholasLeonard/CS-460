# Nicholas Leonard

## Homework 6

This assignment was about accessing a pre-built database and displaying results for the user. It involved querying the database to display name and contact information for the searched person. I also had to display additional company and item information if the searched person was a customer of the database owner. For this assignment I utilized Entity Framework and used a "generate from an existing database from code" model to access the database. This assignment was intense, with a lot to learn and understand. It was a lot of fun, but it was also frustrating and a lot of work. All in all, it was educational, challenging, fun, and frustrating, but I learned a lot.

### Important Links

Here is the link to my GitHub repository, which houses all of the source code for this project and others. <br/>
[GitHub Repository](https://github.com/NicholasLeonard/NicholasLeonard.github.io)<br/>

Here is the link to a demo video of the application in action. <br/>
[Demo Video](https://youtu.be/trBopo6a7tI)<br/>

This link will take you back to my main Portfolio page.<br/>
[Home](../../index.md)

### Step 1. Restoring, Setting up, and Connecting to the Database

Before I could even start the project, I had to restore the database. To do this, I downloaded Microsoft SQL Server Management Studio and a back up file of the World Wide Importers database from Microsoft. I then went through the simple process of restoring the database, which involved using the Management studio and the .bak file of the database from Microsoft. After the database had been restored, I went to Visual Studio and connected to the database via the server explorer. I had to add two lines of code to the `Global.asax.cs` file to be able to use geography types and to solve a problem that my Professor found while writing the assignment. I also had to install entity framework and `Microsoft.SqlServer.Types` using NuGet package manager as the final step of the setup process.

```csharp
...
// For Spatial types, i,e, DbGeography
            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
            //This next line is a fix that came from: https://stackoverflow.com/questions/13174197/microsoft-sqlserver-types-version-10-or-higher-could-not-be-found-on-azure/40166192#40166192
            SqlProviderServices.SqlServerTypesAssemblyName = typeof(SqlGeography).Assembly.FullName;
...
```

### Step 2. The Content and Coding

#### Feature 1 People Search

For this feature, I was asked to make a web page that allowed the user to enter a first name, last name, or part of a name into a search bar and then display the results beneath the bar. To create the search bar, I used a form that utilized the GET method and a single input field with a submit button to send the data to the server.

```html
@using (Html.BeginForm("Index", "Home", FormMethod.Get))
{@*Form with search bar for submitting to the server*@
    <div class="row">
        <div class="col-lg-8">
            <div class="form-group">
                <div class="search">
                    <h3 class="text-center">Find a Client</h3>
                    <input class="form-control" placeholder="Search name..." type="text" name="client" required />
                    <button class="btn-primary button btn" type="submit">Search</button>
                </div>

            </div>
        </div>
    </div>
}
```

In order to display the results, I had to create a View Model that contains properties for all of the data that I wanted to display in the view. I then initialize it with queries in my controller and pass it back to the view for displaying. The search bar result only uses the name property from this model class, but the rest of the properties are used in other views later in the assignment. The `ItemPurchased` class is used to hold information about specific items, which I show later on.

```csharp
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
```

The links were made with razor action link functions that routed to the details page, which displayed the details of the person searched for. I also had a toggle `viewbag` that would only display the results if a search had been performed or displayed a no results message if the search returned no results.

```html
@if (ViewBag.Toggle == 1)
{@*Loop for displaying all of the results as an Actionlink to route to details page*@
    foreach (var s in Model)
    {
        <ul style="list-style-type: none;">
            <li>
                @Html.ActionLink(s.Name, "Details", "Home", routeValues: new { result = s.Name }, htmlAttributes: null)
            </li>
        </ul>

    }
}
else if(ViewBag.Toggle == 2)
{@*Displays if no results were found*@
    <p>No results match your search.</p>
}
```

#### The Action Method

After the view was set up to display the results, I had to create the logic for the Controller. I first wanted to add some error handling in case someone messed with the query strings instead of actually using the search bar. So I put an if statement that checked if the query string was empty or null, if it was not empty, then I ran my query. The query generated a list of `PersonVM` view models, which I then checked to see if they were empty to determine if the search returned anything. If it did, I set `ViewBag.Toggle` to one and passed the list to the view, which then displays the result. If it did not, I set `ViewBag.Toggle` to 2 and passed the empty list to the view, which then displayed the "No results" message. If the query string is null or empty, then none of that code executes and it just displays the default view with the search bar.

```csharp
[HttpGet]
        public ActionResult Index()
        {//gets query string from form submission with a get method
            string client = Request.QueryString["client"];
            
            //checks to make sure a search has actually been made. Handles some checking for query string manipulation.
            if (client != null && client != "" && client != " ")
            {
                List<PersonVM> SearchResult = db.People.Where(person => person.FullName.Contains(client)).Where(p => p.PersonID
                            != 1).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();

                if (SearchResult.FirstOrDefault() == null)
                {//Displays a no results found message
                    ViewBag.Toggle = 2;
                    return View(SearchResult);
                }
                else
                {//Displays results on page
                    ViewBag.Toggle = 1;
                    return View(SearchResult);
                }
            else
            {//displays the default search page
                return View();
            }
        }
```

#### The Details Page

After the results displayed on the search page, I then had to create the controller logic for the details page. I started this, by running a query against the database with the name of the person in the link that was clicked on. This generated a list of initialized `PersonVM`s, which I then passed to the details view and displayed them.

```csharp
List<PersonVM> DetailPerson = db.People.Where(person => person.FullName == result).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();
```

Once the query result was passed to the view, I was able to display it by running a `foreach` loop and iterating over the list displaying the results. I also included a placeholder image for a profile picture.

```html
@*Default results display section. This section is for details about an individual person.*@
<div class="container container-details">
    <div class="row">
        <div class="col-lg-9">
            <div id="details" class="clearfix">
                <h3 id="details-name">@Model.FirstOrDefault().Name</h3>
                <hr />
                <div class="col-sm-3">
                    <p>Preferred Name:</p>
                    <p>Phone:</p>
                    <p>Fax:</p>
                    <p>Email:</p>
                    <p>Registered Since:</p>
                </div>
                <div class="col-sm-5">
                    <p>@Model.FirstOrDefault().PreferredName</p>
                    <p><a href="tel:@Model.FirstOrDefault().PhoneNumber">@Model.FirstOrDefault().PhoneNumber</a></p>
                    <p>@Model.FirstOrDefault().FaxNumber</p>
                    <p><a href="mailto:@Model.FirstOrDefault().EmailAddress">@Model.FirstOrDefault().EmailAddress</a></p>
                    <p>@Model.FirstOrDefault().ValidFrom</p>
                </div>
                <div class="col-sm-offset-3" style="padding-bottom: 1em;">
                    <a href="https://placeholder.com"><img src="https://via.placeholder.com/150x200" /></a>
                </div>
            </div>
        </div>
    </div>
</div>
```

### Step 3. More Content and Coding Extended Features

#### Feature 2 Customer Sales Dashboard

This feature involves expanding upon the previous search feature, by listing more information in the details page. Specifically, if the person searched for is a customer of World Wide Importers, additional information needs to be displayed about the company that the customer works for. This information includes company name and contact info, total number of orders, gross sales and profit, as well as a list of the top 10 items sold to the customer and the sales person in charge of handling the item. To do this, I added additional logic to the details action method in the controller.

#### The first Details

I started by running two queries. The first query retrieved the details that were used in the previous feature. The second query determined if the search subject was a customer of World Wide Importers. If they were a customer, then it returned a list containing all of the customer information such as the name of the company, company phone number, fax, and website.

```csharp
 //Get's the default information for the details page.
            List<PersonVM> DetailPerson = db.People.Where(person => person.FullName == result).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();
            
            //This is in case someone messes with the url on the details page
            if(DetailPerson.FirstOrDefault() == null)
            {
                return RedirectToAction("Index");
            }

            //Customer Company Details. See PersonVM.cs
            var CustomerDetails = db.People
                                    .Where(p => p.FullName == result)
                                    .Include("PrimaryContactPersonID")
                                    .SelectMany(p => p.Customers2).ToList();
```

I then added an if statement to check if `CustomerDetails` has any values. If it does not, then it just displays the default details from feature 1, if it does, then I continue to gather information to initialize my view model. To initialize my view model, I ran a query `ItemDetails` to get all of the info about the top 10 items sold to the customer. I then ran a query `SalesMen` to get all of the salespeople for the top 10 items. I then ran a `for` loop to make a list of `ItemPurchased` classes that contains all of the details for the top 10 items to initialize my view model.

```csharp
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
```

#### Initializing my View Model

Once I had all of the information I needed, I created a new list of `PersonVM` view models and initialized it with all of the data that I gathered from the database. The default details are initialized from the `DetailPerson` list that I made earlier. This was done by selecting the first element of the list and accessing each individual property. I followed the same process to initialize the company details section of the `PersonVM` model. For the Purchase History section, I used queries to initialize the Orders, Gross Sales, and Gross Profit properties by counting and summing the appropriate fields in the tables. To initialize the `ItemPurchaseSummary` list, I just assigned it the `top10Items` list that was made previously. I then passed the list of initialized view models to the view and displayed the results.

```csharp
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
```

#### The Updated Details View

Once I passed the view model to the view, it was time to display it. The first section that I displayed was the default details about the search subject. The next section I displayed was the company details section.

```html
@if (ViewBag.Toggle == 1)
{@*Customer details section. Displays details about the company.*@
    <div class="container container-details">
        <div class="row">
            <div class="col-lg-9">
                <div id="details" class="clearfix">
                    <h3 id="details-name">Company Details</h3>
                    <hr />
                    <div class="col-sm-3">
                        <p>Company Name:</p>
                        <p>Phone Number:</p>
                        <p>Fax Number:</p>
                        <p>Website:</p>
                        <p>Customer Since:</p>
                    </div>
                    <div class="col-sm-5">
                        <p>@Model.FirstOrDefault().CompanyName</p>
                        <p><a href="tel:@Model.FirstOrDefault().CompanyPhone">@Model.FirstOrDefault().CompanyPhone</a></p>
                        <p>@Model.FirstOrDefault().CompanyFax</p>
                        <p><a href="@Model.FirstOrDefault().CompanyWebsite">@Model.FirstOrDefault().CompanyWebsite</a></p>
                        <p>@Model.FirstOrDefault().CompanyValidFrom</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
```

The next thing I displayed was the Purchase Summary, which contained the total number of orders, the gross sales, and the gross profit. I added some formatting in the view where I switched to C# using `@{}` to declare a new string and format it and then I displayed the formatted string rather then the actual property itself.

```html
<div class="container container-details">
        <div class="row">
            <div class="col-lg-9">
                <div id="details" class="clearfix">
                    <h3 id="details-name">Purchase History</h3>
                    <hr />
                    <div class="col-sm-3">
                        <p>Total Orders:</p>
                        <p>Gross Sales:</p>
                        <p>Gross Profit:</p>
                        @*This section displays Purchase History details. The code below provides fromatting to dollar values.*@
                    </div>
                    <div class="col-sm-5">
                        <p>@Model.FirstOrDefault().Orders</p>
                        <p>@{string sales = String.Format("{0:C2}", Model.FirstOrDefault().GrossSales);}@sales</p>
                        <p>@{string profit = String.Format("{0:C2}", Model.FirstOrDefault().GrossProfit);}@profit</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
```

Once all of that was done, the last thing to display was a table containing the details about the top 10 items sold to the customer. I also formatted the line profit property and displayed the formatted string rather then the actual property itself.

```html
@*This section displays details about the top 10 items sold to the customer.*@
    <div class="container container-details">
        <div class="row">
            <div class="col-lg-9">
                <div id="details" class="clearfix">
                    <h3 id="details-name">Item Summary</h3>
                    <hr />
                    <table class="table table-striped table-responsive table-condensed">
                        <tr>
                            <th>StockItemID</th>
                            <th>Description</th>
                            <th>Line Profit</th>
                            <th>Sales Person</th>
                        </tr>
                        
                            @foreach(var item in Model.FirstOrDefault().ItemPurchaseSummary)
                            {
                                <tr>
                                    <td>@item.StockItemID</td>
                                    <td>@item.ItemDescription</td>
                                    <td>@{string LineProfit = string.Format("{0:C2}", item.LineProfit);}@LineProfit</td>
                                    <td>@item.SalesPerson</td>
                                </tr>
                            }
                        
                    </table>
                </div>
            </div>
        </div>
    </div>
}
```

And that is how I created the search page for the client, this time with a pre-existing database. Thanks for reading.
