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

        public virtual User User { get; set; }

        public virtual WorkoutExercise WorkoutExercise { get; set; }
    }
}
