namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanWorkout")]
    public partial class PlanWorkout
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlanWorkout()
        {
            UserWorkouts = new HashSet<UserWorkout>();
        }

        [Key]
        public int LinkID { get; set; }

        public int PlanId { get; set; }

        public int WorkoutId { get; set; }

        public int DayOfPlan { get; set; }

        public virtual Plan Plan { get; set; }

        public virtual Workout Workout { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserWorkout> UserWorkouts { get; set; }
    }
}
