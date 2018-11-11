using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using Giph.Models;

namespace Giph.Controllers
{
    public class ApiController : Controller
    {//establishes a connection to the searchlog database
        SearchContext db = new SearchContext();

        /// <summary>
        /// Handles ajax request for content from giphy api
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Giph(string word)
        {
            //constructs the uri for requesting from the giphy api
            string key = ConfigurationManager.AppSettings["GiphyAPIKey"];
            string URL = "https://api.giphy.com/v1/stickers/translate?api_key=" + key + "&s=" + word;

            //creates the connection between the controller and the giphy api
            WebRequest request = HttpWebRequest.Create(URL);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            //creates a new stream to the giphy api and a new streamreader for that stream
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            //reads the response from the Api
            string ApiResponse = reader.ReadToEnd();
            //parses the json object to get the necessary data and converts it to a string for entry in the next parse
            string data = JObject.Parse(ApiResponse)["data"].ToString();
            
            //Debug.WriteLine(data);
            //initializes a new record for entry into the database
            Search search = new Search
            {
                Time = DateTime.Now,
                Request = Request.HttpMethod,
                IPAddress = Request.UserHostAddress,
                BrowserType = Request.Browser.Type,
                AgentType = Request.UserAgent
            };

            //adds record to the database
            db.Searches.Add(search);
            db.SaveChanges();

            //closes connections to Giphy Api
            reader.Close();
            dataStream.Close();
            response.Close();

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Disposes of connection to database
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