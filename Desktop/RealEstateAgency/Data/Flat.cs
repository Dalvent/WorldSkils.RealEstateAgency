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
        public int? HouseNum { get; set; }

        public int? FlatNum { get; set; }

        public int Floor { get; set; }

        public int RoomCount { get; set; }
    }
}
