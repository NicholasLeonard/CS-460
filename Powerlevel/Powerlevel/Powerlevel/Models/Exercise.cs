namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Exercise")]
    public partial class Exercise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercise()
        {
            ExerciseEquipments = new HashSet<ExerciseEquipment>();
            ExerciseFlags = new HashSet<ExerciseFlag>();
            ExerciseImages = new HashSet<ExerciseImage>();
        }

        public int ExerciseId { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Type { get; set; }

        [Required]
        [StringLength(64)]
        public string MainMuscleWorked { get; set; }

        [Required]
        [StringLength(3000)]
        public string Instructions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExerciseEquipment> ExerciseEquipments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExerciseFlag> ExerciseFlags { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExerciseImage> ExerciseImages { get; set; }
    }
}
