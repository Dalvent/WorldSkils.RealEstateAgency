namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseFilter")]
    public partial class HouseFilter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DemandId { get; set; }

        public int MinFloorCount { get; set; }

        public int MaxFloorCount { get; set; }

        public int MinRoomCount { get; set; }

        public int MaxRoomCount { get; set; }

        public virtual Filter Filter { get; set; }
    }
}
