namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Deal")]
    public partial class Deal
    {
        [Key]
        public int Id { get; set; }

        public int DemandId { get; set; }
        public int SupplyId { get; set; }

        public virtual Demand Demand { get; set; }
        public virtual Supply Supply { get; set; }

        public Commission CalculateCommission()
        {
            var commission = new Commission();
            commission.SupplinderCommision = CalculateSupplinderCommision();
            commission.DemanderCommision = CalculateDemanderCommision();
            commission.SupplinderRealtorCommision = CalculateSupplinderRealtorCommision(commission.SupplinderCommision);
            commission.DemanderRealtorCommision = CalculateDemanderRealtorCommision(commission.DemanderCommision);
            commission.ComponyCommision = (commission.SupplinderCommision + commission.DemanderCommision) -
                (commission.SupplinderRealtorCommision + commission.DemanderRealtorCommision);
            return commission;
        }

        private decimal CalculateSupplinderCommision()
        {
            var currentSupply = Supply;
            var currentEstle = Supply.Estate;
            return currentEstle.CalculateCommission(currentSupply.Price);
        }

        private decimal CalculateDemanderCommision()
        {
            var currentPrice = Supply.Price;
            return currentPrice / 100 * 3;
        }

        private decimal CalculateSupplinderRealtorCommision(decimal supplinderCommission)
        {
            var realtorPersent = Supply.Realtor.DealShare;
            realtorPersent = realtorPersent == null ? realtorPersent : 45.0;
            return supplinderCommission / 100 * (decimal)realtorPersent;
        }

        private decimal CalculateDemanderRealtorCommision(decimal supplinderCommission)
        {
            var realtorPersent = Demand.Realtor.DealShare;
            realtorPersent = realtorPersent == null ? realtorPersent : 45.0;
            return supplinderCommission / 100 * (decimal)realtorPersent;
        }
    }

    public struct Commission
    {
        public decimal SupplinderCommision { get; set; }
        public decimal DemanderCommision { get; set; }
        public decimal SupplinderRealtorCommision { get; set; }
        public decimal DemanderRealtorCommision { get; set; }
        public decimal ComponyCommision { get; set; }
    }
}
