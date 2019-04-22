namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkoutEvent")]
    public partial class WorkoutEvent
    {
        [Key]
        public int EventId { get; set; }

        [StringLength(128)]
        public string Title { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        [StringLength(20)]
        public string StatusColor { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int UserId { get; set; }

        public int WorkoutId { get; set; }

        public virtual User User { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
