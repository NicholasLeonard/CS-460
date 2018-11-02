using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BigDatabase.Models.ViewModels
{
    public class PersonVM
    {
        public string Name { get; set; }
        public string PreferredName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}