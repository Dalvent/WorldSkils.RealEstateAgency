namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Filter")]
    public abstract partial class Filter
    {
        [Key]
        public int DemandId { get; set; }
        public double? MinArea { get; set; }
        public double? MaxArea { get; set; }
        public int? MinCoordinateLatitude { get; set; }
        public int? MaxCoordinateLatitude { get; set; }
        public int? MinCoordinateLongitude { get; set; }
        public int? MaxCoordinateLongitude { get; set; }
        [StringLength(50)]
        public string Street { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        public int? HouseNum { get; set; }
        public int? FlatNum { get; set; }

        [Column(TypeName = "money")]
        public decimal? MinPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? MaxPrice { get; set; }
        public string FullAddress
        {
            get
            {
                string address = String.Empty;
                address += City != null ? City + " " : String.Empty;
                address += Street != null ? Street + " " : String.Empty;
                address += HouseNum != null ? HouseNum + " " : String.Empty;
                address += FlatNum != null ? FlatNum + " " : String.Empty;
                return address;
            }
        }
        public string TypeName => EstleTypeConverter.ToString(EstleType);
        public abstract EstleType EstleType { get; }
        public virtual Demand Demand { get; set; }
    }
}
