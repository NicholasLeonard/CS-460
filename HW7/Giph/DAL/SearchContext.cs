namespace Giph.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SearchContext : DbContext
    {
        public SearchContext()
            : base("name=SearchContext")
        {
        }

        public virtual DbSet<Search> Searches { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
