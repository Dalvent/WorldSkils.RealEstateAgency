//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RealEstateAgency.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class House
    {
        public int SupplyId { get; set; }
        public int FloorCount { get; set; }
        public int RoomCount { get; set; }
    
        public virtual Estate Estate { get; set; }
    }
}