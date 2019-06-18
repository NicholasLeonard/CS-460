namespace Powerlevel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Avatar")]
    public partial class Avatar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Avatar()
        {
            AvatarUnlocks = new HashSet<AvatarUnlock>();
        }

        [Key]
        public int AvaId { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Imagefile { get; set; }

        [Required]
        [StringLength(64)]
        public string Type { get; set; }

        [Required]
        [StringLength(64)]
        public string Race { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AvatarUnlock> AvatarUnlocks { get; set; }
    }
}
