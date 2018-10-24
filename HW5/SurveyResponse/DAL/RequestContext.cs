using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SurveyResponse.Models;
namespace SurveyResponse.DAL
{
    public class RequestContext : DbContext
    {
        public RequestContext() : base("name=ServiceRequests")
        {
            
        }

        public virtual DbSet<ServiceRequests> ServiceRequests { get; set; }
    }
}