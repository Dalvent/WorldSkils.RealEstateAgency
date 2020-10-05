namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Text;

    [Table("Estate")]
    public abstract partial class Estate
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public double? Area { get; set; }
        public int? HouseNum { get; set; }
        public int? FlatNum { get; set; }

        public float? CoordinateLatitude { get; set; }
        public float? CoordinateLongitude { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

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
        public string CoodrinateString 
        { 
            get
            {
                var coodrdinate = String.Empty;
                coodrdinate += CoordinateLatitude.ToString() + " " +
                    "";
                coodrdinate += CoordinateLongitude.ToString();
                return coodrdinate;
            }
        } 
        public abstract EstleType EstleType { get; }
        public string TypeName => EstleTypeConverter.ToString(EstleType);

        public override string ToString()
        {
            return $"Стоймость: {Price}; Адрес: {FullAddress}";
        }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
