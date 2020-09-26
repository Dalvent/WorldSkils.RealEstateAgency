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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplyId { get; set; }

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
        public abstract string TypeName { get; } 

        public Supply Supply { get; set; }
    }
}
