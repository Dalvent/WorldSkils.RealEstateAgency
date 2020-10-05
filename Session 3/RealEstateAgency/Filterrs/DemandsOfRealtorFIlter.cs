using RealEstateAgency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    class DemandsOfRealtorFIlter : ICollectionFilter
    {
        public Realtor Context { get; set; }
        public DemandsOfRealtorFIlter(Realtor context)
        {
            this.Context = context;
        }

        public IEnumerable UseFilter(IEnumerable collection, string pattern)
        {
            return collection.Cast<Demand>().Where(item => item.Realtor == Context);
        }
    }
}
