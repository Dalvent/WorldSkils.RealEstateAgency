namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseFilter")]
    public partial class HouseFilter : Filter
    {

        public int? MinFloorCount { get; set; }

        public int? MaxFloorCount { get; set; }

        public int? MinRoomCount { get; set; }

        public int? MaxRoomCount { get; set; }

        public override EstleType EstleType => EstleType.House;

        public override string ToString()
        {
            return base.ToString() + $" этажи: {MinFloorCount}-{MaxFloorCount};" +
                $" комнаты: {MinRoomCount}-{MaxRoomCount}";
        }

        public override bool IsEstleSuitable(Estate estate)
        {
            if(!base.IsEstleSuitable(estate)) 
                return false;

            var houseEstle = (House)estate;

            if(MinFloorCount != null || houseEstle.FloorCount < MinFloorCount)
                return false;
            if(MaxFloorCount != null || houseEstle.FloorCount > MaxFloorCount)
                return false;

            if(MinRoomCount != null || houseEstle.RoomCount < MinRoomCount)
                return false;
            if(MaxRoomCount != null || houseEstle.RoomCount > MaxRoomCount)
                return false;

            return true;
        }
    }
}
