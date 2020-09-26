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
        public override string TypeName => "Дом";
    }
}
