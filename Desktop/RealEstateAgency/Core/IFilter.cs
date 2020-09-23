using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    public interface IFilter
    {
        /// <summary>
        /// Фитльтрация.
        /// </summary>
        /// <param name="pattern">Текстовый шаблон для фильтрации.</param>
        /// <returns></returns>
        IList<T> Filter<T>(IList<T> collection, string pattern);
    }
}
