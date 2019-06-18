namespace Giph.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /// <summary>
    /// Model for logging giph requests in the database
    /// </summary>
    public partial class Search
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        [Required]
        [StringLength(10)]
        public string Request { get; set; }

        [Required]
        [StringLength(20)]
        public string IPAddress { get; set; }

        [Required]
        [StringLength(20)]
        public string BrowserType { get; set; }

        [Required]
        [StringLength(500)]
        public string AgentType { get; set; }
    }
}
