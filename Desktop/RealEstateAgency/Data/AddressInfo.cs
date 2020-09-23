namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddressInfo")]
    public partial class AddressInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AddressInfo()
        {
            Estate = new HashSet<Estate>();
            Filter = new HashSet<Filter>();
        }

        public int Id { get; set; }
        [StringLength(80)] 
        public string City { get; set; }
        [StringLength(80)] 
        public string Street { get; set; }
        public int? HouseNumber { get; set; }
        public int? FlatNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Estate> Estate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Filter> Filter { get; set; }
    }
}
