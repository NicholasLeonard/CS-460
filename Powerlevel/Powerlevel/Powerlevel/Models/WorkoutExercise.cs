namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkoutExercise")]
    public partial class WorkoutExercise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkoutExercise()
        {
            UserCurrWorkouts = new HashSet<UserCurrWorkout>();
            UserWorkoutHistories = new HashSet<UserWorkoutHistory>();
        }

        [Key]
        public int LinkId { get; set; }

        public int WorkoutId { get; set; }

        public int ExerciseId { get; set; }

        public int? OrderNumber { get; set; }

        public virtual Exercise Exercise { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserCurrWorkout> UserCurrWorkouts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWorkoutHistory> UserWorkoutHistories { get; set; }

        public virtual Workout Workout { get; set; }
    }
}
