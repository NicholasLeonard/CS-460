namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserCurrWorkout")]
    public partial class UserCurrWorkout
    {
        [Key]
        public int UCWId { get; set; }

        public int UserId { get; set; }

        public int UserActiveWorkout { get; set; }

        //This exists for Workout History; should not be completed upon creation/starting the workout, only upon "completion" on the site
        public bool WorkoutCompleted { get; set; } = false;

        private DateTime Date = DateTime.Now;

        public DateTime CompletedTime
        {
            get { return Date; }
            set { Date = value; }
        }

        public virtual User User { get; set; }

        public virtual WorkoutExercise WorkoutExercise { get; set; }
    }
}