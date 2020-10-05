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
    }
}
