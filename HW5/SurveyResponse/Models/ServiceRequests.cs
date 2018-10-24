using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SurveyResponse.Models
{
    public class ServiceRequests
    {
        [Required, MaxLength(20)]
        public string FirstName { get; set; }
        [Required, MaxLength(20)]
        public string LastName { get; set; }
        [Required, MaxLength(40)]
        public string ApartmentName { get; set; }
        [Required]
        public int UnitNumber { get; set; }
        [Phone, Required]
        public string Phone { get; set; }
        [Required, MaxLength(500)]
        public string Comments { get; set; }
        public bool EnterForMaintenance { get; set; }
    }
}