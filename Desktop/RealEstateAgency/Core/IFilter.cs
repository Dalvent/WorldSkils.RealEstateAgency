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
        /// Коллекция для фильтрации.
        /// </summary>
        IList<object> Context { get; set; }
        /// <summary>
        /// Фитльтрация.
        /// </summary>
        /// <param name="pattern">Текстовый шаблон для фильтрации.</param>
        /// <returns></returns>
        IList<object> GetFilteredPersonInfos(string pattern);
    }
}
