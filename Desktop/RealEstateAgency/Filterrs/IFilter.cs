using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    public interface ICollectionFilter
    {
        /// <summary>
        /// Фитльтрация.
        /// </summary>
        /// <param name="collection">Коллекция для фильтрации.</param>
        /// <param name="pattern">Текстовый шаблон для фильтрации.</param>
        /// <returns></returns>
        IEnumerable UseFilter(IEnumerable collection, string pattern);
    }
}
