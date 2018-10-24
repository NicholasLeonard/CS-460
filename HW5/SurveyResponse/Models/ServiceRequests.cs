using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SurveyResponse.Models
{
    public class ServiceRequests
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ApartmentName { get; set; }
        public int UnitNumber { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Comments { get; set; }
        public bool EnterForMaintenance { get; set; }
    }
}