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
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.RealtorId);

            modelBuilder.Entity<Deal>()
                .Property(e => e.Commission)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Demand>()
                .HasMany(e => e.Deal)
                .WithRequired(e => e.Demand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estate>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Estate>()
                .HasOptional(e => e.Flat);

            modelBuilder.Entity<Estate>()
                .HasOptional(e => e.House);

            modelBuilder.Entity<Estate>()
                .HasOptional(e => e.LandPlot);

            modelBuilder.Entity<Estate>()
                .HasOptional(e => e.Supply)
                .WithRequired(e => e.Estate);

            modelBuilder.Entity<Filter>()
                .Property(e => e.MinPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Filter>()
                .Property(e => e.MaxPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Filter>()
                .HasOptional(e => e.Demand)
                .WithRequired(e => e.Filter);

            modelBuilder.Entity<Filter>()
                .HasOptional(e => e.FlatFilter);

            modelBuilder.Entity<Filter>()
                .HasOptional(e => e.HouseFilter);

            modelBuilder.Entity<Filter>()
                .HasOptional(e => e.LandPlotFilter);

            modelBuilder.Entity<Realtor>()
                .HasMany(e => e.Supply)
                .WithRequired(e => e.Realtor)
                .HasForeignKey(e => e.ClientId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supply>()
                .HasMany(e => e.Deal)
                .WithRequired(e => e.Supply)
                .WillCascadeOnDelete(false);
        }
    }
}
