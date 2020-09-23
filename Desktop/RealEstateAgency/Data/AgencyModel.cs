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

        public virtual DbSet<AddressInfo> AddressInfos { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Deal> Deals { get; set; }
        public virtual DbSet<Demand> Demands { get; set; }
        public virtual DbSet<Estate> Estates { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
        public virtual DbSet<Flat> Flats { get; set; }
        public virtual DbSet<FlatFilter> FlatFilters { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<HouseFilter> HouseFilters { get; set; }
        public virtual DbSet<LandPlot> LandPlots { get; set; }
        public virtual DbSet<LandPlotFilter> LandPlotFilters { get; set; }
        public virtual DbSet<Realtor> Realtors { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressInfo>()
                .HasMany(e => e.Estate)
                .WithRequired(e => e.AddressInfo)
                .HasForeignKey(e => e.Address)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AddressInfo>()
                .HasMany(e => e.Filter)
                .WithRequired(e => e.AddressInfo)
                .HasForeignKey(e => e.Address)
                .WillCascadeOnDelete(false);

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
                .HasOptional(e => e.FlatFilter)
                .WithRequired(e => e.Filter);

            modelBuilder.Entity<Flat>()
                .HasOptional(e => e.Estate)
                .WithRequired(e => e.Flat);

            modelBuilder.Entity<House>()
                .HasOptional(e => e.Estate)
                .WithRequired(e => e.House);

            modelBuilder.Entity<HouseFilter>()
                .HasOptional(e => e.Filter)
                .WithRequired(e => e.HouseFilter);

            modelBuilder.Entity<LandPlot>()
                .HasOptional(e => e.Estate)
                .WithRequired(e => e.LandPlot);

            modelBuilder.Entity<LandPlotFilter>()
                .HasOptional(e => e.Filter)
                .WithRequired(e => e.LandPlotFilter);

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
