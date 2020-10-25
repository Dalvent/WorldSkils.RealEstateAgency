namespace RealtorEventApi.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RealtorEvent")]
    public partial class RealtorEvent
    {
        [Key]
        [StringLength(36)]
        public string Uuid { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RealtorId { get; set; }
        public long StartDateTime { get; set; }

        public long? Duration { get; set; }

        [StringLength(80)]
        public string Type { get; set; }
        public string Comment { get; set; }

        public static bool IsRealtorEventType(string typeString)
        {
            switch(typeString)
            {
            case "presentation":
            case "meeting":
            case "call":
                return true;
            }
            return false;
        }
    }
}
