namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExerciseFlag")]
    public partial class ExerciseFlag
    {
        [Key]
        public int FlagId { get; set; }

        public int ExerciseId { get; set; }

        [StringLength(64)]
        public string FlagName { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
