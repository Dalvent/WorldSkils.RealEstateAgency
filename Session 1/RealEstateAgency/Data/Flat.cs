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
    }
}
