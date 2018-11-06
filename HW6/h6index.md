# Nicholas Leonard
<br/>
## Homework 6

This assignment was about accessing a pre-built database and displaying results for the user. It involved querying the database to display name and contact information for the queried person as well as additional company and item information if they were a customer of the database owner. For this assignment we utilized Entity Framework and did a generate from an existing database from code model to access the database. This assignment was intense, with a lot to learn and understand. It was a lot of fun, but it was also frustrating and a lot of work. All in all, it was educational, challenging, fun, and frustrating to no end.

### Important Links
Here is the link to my github repository, which houses all of the source code for this project and others. <br/>
[Github Repository](https://github.com/NicholasLeonard/NicholasLeonard.github.io)<br/>

Here is the link to a demo video of the application in action. <br/>
(Coming Soon!)<br/>

This link will take you back to my main Portfolio page.<br/>
[Home](../index.md)

### Step 1. Restoring, Setting up, and Connecting to the Database
Before I could even start the project, I had to restore the database. To do this, I downloaded Microsoft SQL Server Management Studio and a back up file of the World Wide Importers database from Microsoft. I then went through the simple process of restoring the database. After the database had been restored, I went to Visual Studio and connected to it via the server explorer. I had to add some things to the `Global.asax.cs` file so that it would function properly. I also had to install entity framework and `Microsoft.SqlServer.Types` using NuGet package manager as the final step of the setup process.

```csharp
...
// For Spatial types, i,e, DbGeography
            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
            //This next line is a fix that came from: https://stackoverflow.com/questions/13174197/microsoft-sqlserver-types-version-10-or-higher-could-not-be-found-on-azure/40166192#40166192
            SqlProviderServices.SqlServerTypesAssemblyName = typeof(SqlGeography).Assembly.FullName;
...
```
### Step 2. The Content and Coding
#### Feature 1. People Search
For this feature, I was asked to make a web page that allowed the user to enter a first name, last name, or part of a name, into a search bar and then display the result beneath it. To create the search bar, I used a form and a single input field with a submit button and utilizing a GET method.

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

In order to display the results, I had to create a View Model that contains properties for all of the data that I wanted to display in the view. I then initialize it with queries in my controller and pass it back to the view for displaying. The search bar result only uses the name property from this class, but the rest are used on other views later in the assignment. 

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
After the view was set up to display the results, I had to create the logic in the Controller. I first wanted to add some error handling in case someone messed with the query strings instead of actually using the search bar. So, I put an if statement that checked if the query string was empty or null, if it wasn't, then I ran my query. The query generated a list of my custom made view model, which I then checked to see if the search returned anything. If it did, I set `ViewBag.Toggle` to one and passed the list to the view, which then displays the result. If it didn't, I set `ViewBag.Toggle` to 2 and passed the list to the view, which then displayed the no results found message. If the query string is null or empty, then none of that executes and it just displays the default view with the search bar.

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
After the results displayed, I had to do the logic for the details page. This started by running a query against the database with the name of the person in the link to get their details. This generated a list of `PersonVM`, which allowed me to pass the results to the details view and display them.

```csharp
List<PersonVM> DetailPerson = db.People.Where(person => person.FullName == result).Select(person => new PersonVM { Name = person.FullName, PreferredName = person.PreferredName, PhoneNumber = person.PhoneNumber, FaxNumber = person.FaxNumber, EmailAddress = person.EmailAddress, ValidFrom = person.ValidFrom }).ToList();
```
Once the result was passed to the view, I was able to display it by running a `foreach` loop and iterating over the list displaying the results. I also included a placeholder image for a profile picture.

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
This feature involves