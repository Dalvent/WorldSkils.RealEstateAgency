using RealEstateAgency.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    class SuppliesOfRealtorFIlter : ICollectionFilter
    {
        public Realtor Context { get; set; }
        public SuppliesOfRealtorFIlter(Realtor context)
        {
            this.Context = context;
        }

        public IEnumerable UseFilter(IEnumerable collection, string pattern)
        {
            return collection.Cast<Supply>().Where(item => item.Realtor == Context);
        }
    }
}
