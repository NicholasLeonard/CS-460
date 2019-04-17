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
        public int UCWId { get; set; }

        public int UserId { get; set; }

        public int UserActiveWorkout { get; set; }

        public int ActiveWorkoutStage { get; set; }

        public bool WorkoutCompleted { get; set; }

        public DateTime? CompletedTime { get; set; }

        public virtual User User { get; set; }

        public virtual WorkoutExercise WorkoutExercise { get; set; }
    }
}
