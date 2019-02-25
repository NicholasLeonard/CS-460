namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlanWorkout
    {
        [Key]
        public int LinkID { get; set; }

        public int PlanId { get; set; }

        public int WorkoutId { get; set; }

        public int DayOfPlan { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
