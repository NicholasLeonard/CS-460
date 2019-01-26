namespace milestone3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Topic
    {
        public int TopicId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int? Ranking { get; set; }

        public int Views { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Timestamp { get; set; }
    }
}
