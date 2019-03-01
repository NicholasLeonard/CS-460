namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ExerciseImage")]
    public partial class ExerciseImage
    {
        [Key]
        public int ImageId { get; set; }

        public int ExerciseId { get; set; }

        [Required]
        [StringLength(128)]
        public string ImageName { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
