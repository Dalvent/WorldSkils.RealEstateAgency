using RealEstateAgency.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    class DemandsOfClientFIlter : ICollectionFilter
    {
        public Client Context { get; set; }
        public DemandsOfClientFIlter(Client context)
        {
            this.Context = context;
        }

        public IEnumerable UseFilter(IEnumerable collection, string pattern)
        {
            return collection.Cast<Demand>().Where(item => item.Client == Context);
        }
    }
}
