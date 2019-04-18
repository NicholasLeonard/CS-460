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

        public int UserId { get; set; }

        public int UserActiveWorkout { get; set; }

        public int ActiveWorkoutStage { get; set; }

        //This exists for Workout History; should not be completed upon creation/starting the workout, only upon "completion" on the site
        public bool WorkoutCompleted { get; set; } = false;

        private DateTime Date = DateTime.Now;

        public DateTime CompletedTime
        {
            get { return Date; }
            set { Date = value; }
        }

        public virtual User User { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
