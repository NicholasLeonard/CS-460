namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int UserId { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }
    }
}
