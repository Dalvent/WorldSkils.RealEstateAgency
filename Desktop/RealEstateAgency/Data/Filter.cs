namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Filter")]
    public partial class Filter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DemandId { get; set; }
        public double? MinArea { get; set; }
        public double? MaxArea { get; set; }
        public int? MinCoordinateLatitude { get; set; }
        public int? MaxCoordinateLatitude { get; set; }
        public int? MinCoordinateLongitude { get; set; }
        public int? MaxCoordinateLongitude { get; set; }
        public string Street { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [Column(TypeName = "money")]
        public decimal? MinPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? MaxPrice { get; set; }


        public virtual Demand Demand { get; set; }

        public virtual FlatFilter FlatFilter { get; set; }

        public virtual HouseFilter HouseFilter { get; set; }

        public virtual LandPlotFilter LandPlotFilter { get; set; }
    }
}
