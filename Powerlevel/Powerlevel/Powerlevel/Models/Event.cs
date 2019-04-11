namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int EventId { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        [StringLength(20)]
        public string StatusColor { get; set; }
    }
}
