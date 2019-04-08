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

        private DateTime Date = DateTime.Now;

        public DateTime CurrentTime
        {
            get { return Date; }
            set { Date = value; }
        }

        public int UserId { get; set; }

        public int UserOldWorkout { get; set; }

        public virtual User User { get; set; }

        public virtual WorkoutExercise WorkoutExercise { get; set; }
    }
}
