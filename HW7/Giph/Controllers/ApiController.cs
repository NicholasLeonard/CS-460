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

namespace Giph.Controllers
{
    public class ApiController : Controller
    {
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
            var data = JObject.Parse(ApiResponse)["data"].ToString();
            //parses the json object to get necessary data and converts to string for entry in next parse
            //string images = JObject.Parse(data)["images"].ToString();
            //casts the resulting json object to a json object for passing back to the client
            //var preview = JObject.Parse(images)["preview"].ToString();
            Debug.WriteLine(data);
            /*var test = new
            {
                
            };*/
            
            //closes connections to Giphy Api
            reader.Close();
            dataStream.Close();
            response.Close();
            
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}