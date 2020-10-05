namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LandPlotFilter")]
    public partial class LandPlotFilter : Filter
    {
        public override EstleType EstleType => EstleType.LandPlot;
    }
}
