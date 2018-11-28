namespace AuctionHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bid
    {
        public int BidId { get; set; }

        public int Item { get; set; }

        public int Buyer { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TimeStamp { get; set; }

        public virtual Buyer Buyer1 { get; set; }

        public virtual Item Item1 { get; set; }
    }
}
