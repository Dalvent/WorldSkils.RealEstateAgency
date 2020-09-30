namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Flat")]
    public partial class Flat : Estate
    {
        public int Floor { get; set; }

        public int RoomCount { get; set; }
        public override EstleType EstleType => EstleType.Flat;
        public override decimal CalculateCommission(decimal price)
        {
            decimal constCommision = 36000;
            decimal persentComison = price / 100 * 1;
            return constCommision + persentComison;
        }

        public override string ToString()
        {
            return base.ToString() +
                $"этажи {Floor};" +
                $"комнаты: {RoomCount};";
        }
    }
}
