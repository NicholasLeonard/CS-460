using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SurveyResponse.Models;
namespace SurveyResponse.DAL
{   /// <summary>
/// Used to access ServiceRequest table in database
/// </summary>
    public class RequestContext : DbContext
    {
        public RequestContext() : base("name=ServiceRequests")
        {
            
        }
        /// <summary>
        /// Creates a connection between the MVC application and the database.
        /// </summary>
        public virtual DbSet<ServiceRequests> ServiceRequests { get; set; }
    }
}