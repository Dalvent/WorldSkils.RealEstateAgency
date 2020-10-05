using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    /// <summary>
    /// Представляет собой контейнер с фильтром и заданным для него аргументом.
    /// </summary>
    class FilterWithPattern
    {
        public ICollectionFilter Filter { get; set; }
        public string Pattern { get; set; }
        /// <summary>
        /// Фильтрация.
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public IEnumerable UseFilter(IEnumerable collection)
        {
            return Filter.UseFilter(collection, Pattern);
        }
    }
}
