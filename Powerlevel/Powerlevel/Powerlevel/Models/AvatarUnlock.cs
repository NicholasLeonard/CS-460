namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AvatarUnlock")]
    public partial class AvatarUnlock
    {
        [Key]
        public int UnlockId { get; set; }

        public int UserId { get; set; }

        public int AvaId { get; set; }

        public virtual Avatar Avatar { get; set; }

        public virtual User User { get; set; }
    }
}
