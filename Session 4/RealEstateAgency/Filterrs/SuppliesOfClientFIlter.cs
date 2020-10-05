using RealEstateAgency.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    class SuppliesOfClientFilter : ICollectionFilter
    {
        public Client Context { get; set; }
        public SuppliesOfClientFilter(Client context)
        {
            this.Context = context;
        }

        public IEnumerable UseFilter(IEnumerable collection, string pattern)
        {
            return collection.Cast<Supply>().Where(item => item.Client == Context);
        }
    }
}
