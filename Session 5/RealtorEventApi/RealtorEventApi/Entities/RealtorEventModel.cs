namespace RealtorEventApi.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RealtorEventModel : DbContext
    {
        public RealtorEventModel()
            : base("name=RealtorEventModel")
        {
        }

        public virtual DbSet<Realtor> Realtor { get; set; }
        public virtual DbSet<RealtorEvent> RealtorEvent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RealtorEvent>()
                .Property(e => e.Uuid)
                .IsFixedLength();
        }
    }
}
