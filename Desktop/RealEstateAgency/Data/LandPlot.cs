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
        public override decimal CalculateCommission(decimal price)
        {
            decimal constCommision = 30000;
            decimal persentComison = price / 100 * 2;
            return constCommision + persentComison; 
        }
    }
}
