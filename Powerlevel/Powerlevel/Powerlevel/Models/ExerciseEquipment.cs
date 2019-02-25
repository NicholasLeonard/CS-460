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

        public bool? NoEquipment { get; set; }

        public bool? Bench { get; set; }

        public bool? Dumbells { get; set; }

        public bool? BarbellRack { get; set; }

        public bool? PullupBar { get; set; }

        public bool? Spotter { get; set; }

        public virtual Exercis Exercis { get; set; }
    }
}
