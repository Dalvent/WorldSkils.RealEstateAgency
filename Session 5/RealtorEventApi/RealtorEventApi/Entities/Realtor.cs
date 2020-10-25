namespace RealtorEventApi.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Realtor")]
    public partial class Realtor
    {
        public int Id { get; set; }

        public double? DealShare { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(30)]
        public string MiddleName { get; set; }
    }
}
