namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FlatFilter")]
    public partial class FlatFilter : Filter
    {

        public int? MinFloor { get; set; }

        public int? MaxFloor { get; set; }

        public int? MinRoomCount { get; set; }

        public int? MaxRoomCount { get; set; }

        public override EstleType EstleType => EstleType.Flat;

        public override string ToString()
        {
            return base.ToString() + $" этажи: {MinFloor}-{MaxFloor};" +
                $" комнаты: {MinRoomCount}-{MaxRoomCount}";
        }

        public override bool IsEstleSuitable(Estate estate)
        {
            if(!base.IsEstleSuitable(estate))
                return false;

            var flatEstle = (Flat)estate;

            if(MinFloor != null || flatEstle.Floor < MinFloor)
                return false;
            if(MaxFloor != null || flatEstle.Floor > MaxFloor)
                return false;

            if(MinRoomCount != null || flatEstle.RoomCount < MinRoomCount)
                return false;
            if(MaxRoomCount != null || flatEstle.RoomCount > MaxRoomCount)
                return false;

            return true;
        }
    }
}
