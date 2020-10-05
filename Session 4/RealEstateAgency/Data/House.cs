namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("House")]
    public partial class House : Estate
    {
        public int FloorCount { get; set; }
        public int RoomCount { get; set; }
        public override EstleType EstleType => EstleType.House;
        public override decimal CalculateCommission(decimal price)
        {
            decimal constCommision = 30000;
            decimal persentComison = price / 100 * 1;
            return constCommision + persentComison;
        }

        public override string ToString()
        {
            return base.ToString() + 
                $"этажи: {FloorCount};" +
                $"комнаты: {RoomCount};";
        }
    }
}
