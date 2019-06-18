using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SurveyResponse.Models
{
    /// <summary>
    /// CLass that defines data input for a tenants repair order for apartment complex.
    /// </summary>
    public class ServiceRequests
    {   //Used as the primary key in the database table
        [Key]
        public int ID { get; set; }

        //First name of tenant submitting repair order
        [Required, MaxLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; }

        //Last name of tenant submitting repair order
        [Required, MaxLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; }

        //Name of Apartment building where tenant lives
        [Required, MaxLength(40), Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }

        //Apartment number of tenant's residence
        [Required, Display(Name = "Apartment Number")]
        public int UnitNumber { get; set; }

        //Tenants phone number
        [Required, DataType(DataType.PhoneNumber), RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please format to 999-999-9999"), Display(Name = "Phone Number")]
        public string Phone { get; set; }

        //Description of problem
        [Required, MaxLength(500), Display(Name = "Comments")]
        public string Comments { get; set; }

        //Wether or not maintenance can enter to resolve the problem
        [Display(Name = "Approval to Enter for Maintenance")]
        public bool EnterForMaintenance { get; set; }

        //Used by server to sort entries, it is auto generated
        public DateTime Submitted { get; set; } = DateTime.Now;
    }
}