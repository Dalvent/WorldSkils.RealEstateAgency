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

        public override string ToString()
        {
            return $"{TypeName} {FullAddress} " +
                $"цена:{MinPrice}-{MaxPrice}; " +
                $"площадь:{MinArea}-{MaxArea};";
        }

        public virtual bool IsEstleSuitable(Estate estate)
        {
            if(estate.EstleType != EstleType) return false;

            if(estate.City != null)
            {
                if(estate.City != City)
                    return false;
            }

            if(estate.Street != null)
            {
                if(estate.Street != Street)
                    return false;
            }

            if(estate.HouseNum != null)
            {
                if(estate.HouseNum != HouseNum)
                    return false;
            }

            if(estate.Price != null && MinPrice != null)
            {
                if(estate.Price < MinPrice)
                    return false;
            }
            if(estate.Price != null && MaxPrice != null)
            {
                if(estate.Price > MaxPrice)
                    return false;
            }

            if(estate.Area != null && MinArea != null)
            {
                if(estate.Area < MinArea)
                    return false;
            }
            if(estate.Area != null && MaxArea != null)
            {
                if(estate.Area > MaxArea)
                    return false;
            }

            if(MinCoordinateLatitude != null || estate.CoordinateLatitude < MinCoordinateLatitude)
                return false;
            if(MaxCoordinateLatitude != null || estate.CoordinateLatitude > MaxCoordinateLatitude)
                return false;

            if(MinCoordinateLongitude != null || estate.CoordinateLongitude < MinCoordinateLongitude)
                return false;
            if(MaxCoordinateLongitude != null || estate.CoordinateLongitude > MaxCoordinateLongitude)
                return false;

            return true;
        }
    }
}
