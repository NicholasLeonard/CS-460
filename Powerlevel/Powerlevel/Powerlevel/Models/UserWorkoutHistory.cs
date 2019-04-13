namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserWorkoutHistory")]
    public partial class UserWorkoutHistory
    {
        [Key]
        public int UWHId { get; set; }

        public DateTime? CurrentTime { get; set; }

        public int UserId { get; set; }

        public int UserOldWorkout { get; set; }

        public virtual User User { get; set; }

        public virtual WorkoutExercise WorkoutExercise { get; set; }
    }
}
