namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkoutPlanWorkout")]
    public partial class WorkoutPlanWorkout
    {
        [Key]
        public int LinkID { get; set; }

        public int PlanId { get; set; }

        public int WorkoutId { get; set; }

        public int DayOfPlan { get; set; }

        public virtual Workout Workout { get; set; }

        public virtual WorkoutPlan WorkoutPlan { get; set; }
    }
}
