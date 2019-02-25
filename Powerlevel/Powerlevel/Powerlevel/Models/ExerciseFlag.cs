namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExerciseFlag
    {
        [Key]
        public int FlagId { get; set; }

        public int ExerciseId { get; set; }

        public bool? Sets { get; set; }

        public bool? Reps { get; set; }

        public bool? Duration { get; set; }

        public bool? Distance { get; set; }

        public bool? Weight { get; set; }

        public virtual Exercis Exercis { get; set; }
    }
}
