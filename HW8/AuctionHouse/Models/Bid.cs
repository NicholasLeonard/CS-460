namespace AuctionHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Item { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Buyer { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal Price { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        public virtual Buyer Buyer1 { get; set; }

        public virtual Item Item1 { get; set; }
    }
}
