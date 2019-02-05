namespace milestone3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public int CommentId { get; set; }

        [StringLength(1000)]
        public string Content { get; set; }

        public int? Ranking { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime Timestamp { get; set; }

        public int? TopicId { get; set; }
    }
}
