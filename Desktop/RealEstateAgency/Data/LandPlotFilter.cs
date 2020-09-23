namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LandPlotFilter")]
    public partial class LandPlotFilter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DemandId { get; set; }

        public virtual Filter Filter { get; set; }
    }
}
