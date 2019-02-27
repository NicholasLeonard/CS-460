namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserWorkout")]
    public partial class UserWorkout
    {
        [Key]
        public int UWId { get; set; }

        [Required]
        [StringLength(128)]
        public string UsernameId { get; set; }

        public int UserCurrentPlan { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual PlanWorkout PlanWorkout { get; set; }
    }
}
