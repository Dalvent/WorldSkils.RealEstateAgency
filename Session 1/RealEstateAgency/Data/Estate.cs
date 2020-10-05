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
        public decimal? Price { get; set; }
        public double? Area { get; set; }
        public int? HouseNum { get; set; }
        public int? FlatNum { get; set; }

        public float? CoordinateLatitude { get; set; }
        public float? CoordinateLongitude { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
