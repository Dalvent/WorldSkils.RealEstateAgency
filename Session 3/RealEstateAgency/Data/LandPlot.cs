namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LandPlot")]
    public partial class LandPlot : Estate
    {
        public override EstleType EstleType => EstleType.LandPlot;
    }
}
