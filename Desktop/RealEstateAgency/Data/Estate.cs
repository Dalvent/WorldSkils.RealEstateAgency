namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Estate")]
    public partial class Estate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplyId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public float? Area { get; set; }

        public int? CoordinateLatitude { get; set; }
        public int? CoordinateLongitude { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Street { get; set; }
    }
}
