using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SurveyResponse.Models
{
    public class ServiceRequests
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, MaxLength(40), Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }

        [Required, Display(Name = "Building Number")]
        public int UnitNumber { get; set; }

        [Phone, Required, Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required, MaxLength(500), Display(Name = "Comments")]
        public string Comments { get; set; }

        [Display(Name = "Approval to Enter")]
        public bool EnterForMaintenance { get; set; }

        private DateTime TimeSent = DateTime.Now;
        public DateTime Submitted
        {
            get { return TimeSent; }
            set { TimeSent = value; }
        }
    }
}