namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExerciseEquipment")]
    public partial class ExerciseEquipment
    {
        [Key]
        public int RequirementId { get; set; }

        public int ExerciseId { get; set; }

        [StringLength(64)]
        public string EquipmentName { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
