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

        [Required]
        [StringLength(500)]
        public string WebURL { get; set; }

        public int Rank = 0;
        public int Ranking
        {
            get { return Rank; }
            set { Rank = value; }
        }

        public int View = 0;
        public int Views
        {
            get { return View; }
            set { View = value; }
        }

        public DateTime Date = DateTime.Now;

        public DateTime Timestamp
        {
            get { return Date; }
            set { Date = value; }
        }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
