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
        public int PlanId { get; set; }

        [Required]
        [StringLength(256)]
        public string UserName { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Type { get; set; }

        [Required]
        public string Description { get; set; }

        public int DaysToComplete { get; set; }

        public int NumberOfWorkouts { get; set; }


      public List<WorkoutPlanWorkout> AvailableWorkoutPlan { get; set; }

    }
}
