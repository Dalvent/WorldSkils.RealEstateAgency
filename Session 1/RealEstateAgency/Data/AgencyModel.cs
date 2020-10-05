namespace RealEstateAgency.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AgencyModel : DbContext
    {
        public AgencyModel()
            : base("name=AgencyModel")
        {
        }

        public static AgencyModel Instance { get; } = new AgencyModel();

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Deal> Deal { get; set; }
        public virtual DbSet<Demand> Demand { get; set; }
        public virtual DbSet<Estate> Estate { get; set; }
        public virtual DbSet<Filter> Filter { get; set; }
        public virtual DbSet<Flat> Flat { get; set; }
        public virtual DbSet<FlatFilter> FlatFilter { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<HouseFilter> HouseFilter { get; set; }
        public virtual DbSet<LandPlot> LandPlot { get; set; }
        public virtual DbSet<LandPlotFilter> LandPlotFilter { get; set; }
        public virtual DbSet<Realtor> Realtor { get; set; }
        public virtual DbSet<Supply> Supply { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Demand)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Demand>()
                .HasMany(e => e.Deal)
                .WithRequired(e => e.Demand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estate>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Estate>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.Estate)
                .HasForeignKey(e => e.EstleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Filter>()
                .Property(e => e.MinPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Filter>()
                .Property(e => e.MaxPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Filter>()
                .HasOptional(e => e.Demand)
                .WithRequired(e => e.Filter);

            modelBuilder.Entity<Realtor>()
                .HasMany(e => e.Demand)
                .WithRequired(e => e.Realtor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Realtor>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Realtor)
                .HasForeignKey(e => e.RealtorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supply>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supply>()
                .HasMany(e => e.Deal)
                .WithRequired(e => e.Supply)
                .WillCascadeOnDelete(false);
        }
    }
}
