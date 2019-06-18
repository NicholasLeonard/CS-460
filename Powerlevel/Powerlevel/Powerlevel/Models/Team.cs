using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Powerlevel.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        public int? UserId { get; set; }

        public int? TeamMemId { get; set; }
    }
}