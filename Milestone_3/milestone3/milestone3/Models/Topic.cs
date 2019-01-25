using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace milestone3.Models
{
    public class Topic
    {
        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int Ranking { get; set; }

        public int Views { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        //get timestamp
        public DateTime currentTime = DateTime.Now;

        public DateTime Timestamp
        {
            get { return currentTime; }
            set { currentTime = value; }

        }

    }
}