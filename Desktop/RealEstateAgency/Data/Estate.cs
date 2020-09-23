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

        public int Address { get; set; }

        public double Area { get; set; }

        public virtual AddressInfo AddressInfo { get; set; }

        public virtual Flat Flat { get; set; }

        public virtual House House { get; set; }

        public virtual LandPlot LandPlot { get; set; }

        public virtual Supply Supply { get; set; }
    }
}
