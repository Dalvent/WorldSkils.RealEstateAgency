using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    public class EqualsFilter<T> : ICollectionFilter where T : class
    {
        public EqualsFilter(Func<T, string> predicate)
        {
            this.predicate = predicate;
        }

        private Func<T, string> predicate;

        public IEnumerable UseFilter(IEnumerable collection, string pattern)
        {
            var filteredItems = new List<T>();
            foreach(var item in collection)
            {
                var itemT = item as T;
                if(itemT == null) 
                    continue;
                if(predicate.Invoke(itemT) == pattern)
                {
                    filteredItems.Add(itemT);
                }
            }
            return filteredItems;
        }
    }
}
