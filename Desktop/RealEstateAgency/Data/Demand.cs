namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Demand")]
    public partial class Demand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Demand()
        {
            Deal = new HashSet<Deal>();
        }

        [Key]
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int RealtorId { get; set; }

        public virtual Client Client { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Deal> Deal { get; set; }

        public virtual Filter Filter { get; set; }

        public virtual Realtor Realtor { get; set; }

        public override string ToString()
        {
            return Filter.ToString() + $" от {Client}";
        }
    }
}
