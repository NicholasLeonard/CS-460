namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("WorkoutPlan")]
    public partial class WorkoutPlan

    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan()
        {

            WorkoutPlanWorkouts = new HashSet<WorkoutPlanWorkout>();

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
        public virtual ICollection<WorkoutPlanWorkout> WorkoutPlanWorkouts { get; set; }

    }
}
