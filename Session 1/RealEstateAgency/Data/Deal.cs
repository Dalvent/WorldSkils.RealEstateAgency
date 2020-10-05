namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deal")]
    public partial class Deal
    {
        [Key]
        public int Id { get; set; }

        public int DemandId { get; set; }
        public int SupplyId { get; set; }

        public virtual Demand Demand { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
