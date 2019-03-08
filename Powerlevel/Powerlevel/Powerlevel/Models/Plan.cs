namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

<<<<<<< HEAD:Powerlevel/Powerlevel/Powerlevel/Models/Plan.cs
    [Table("Plan")]
    public partial class Plan
=======
    [Table("WorkoutPlan")]
    public partial class WorkoutPlan
>>>>>>> 72e0e573505120189e00032558cf9bc7517ff38e:Powerlevel/Powerlevel/Powerlevel/Models/WorkoutPlan.cs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan()
        {
<<<<<<< HEAD:Powerlevel/Powerlevel/Powerlevel/Models/Plan.cs
            WorkoutExercises = new HashSet<WorkoutExercise>();
=======
            WorkoutPlanWorkouts = new HashSet<WorkoutPlanWorkout>();
>>>>>>> 72e0e573505120189e00032558cf9bc7517ff38e:Powerlevel/Powerlevel/Powerlevel/Models/WorkoutPlan.cs
        }

        [Key]
        public int PlanId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Type { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }

        public int DaysToComplete { get; set; }

        public int NumberOfWorkouts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
<<<<<<< HEAD:Powerlevel/Powerlevel/Powerlevel/Models/Plan.cs
        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
=======
        public virtual ICollection<WorkoutPlanWorkout> WorkoutPlanWorkouts { get; set; }
>>>>>>> 72e0e573505120189e00032558cf9bc7517ff38e:Powerlevel/Powerlevel/Powerlevel/Models/WorkoutPlan.cs
    }
}
