namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LevelExp")]
    public partial class LevelExp
    {
        [Key]
        public int LevelExpId { get; set; }

        public int Level { get; set; }

        public int Exp { get; set; }

    }
}
