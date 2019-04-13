namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserWorkoutPlan")]
    public partial class UserWorkoutPlan
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        public int PlanId { get; set; }

        public virtual WorkoutPlan WorkoutPlan { get; set; }
    }
}
