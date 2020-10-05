using RealEstateAgency.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    /// <summary>
    /// Фильтр Левенштейна для выбранного поля класса T.\
    /// </summary>
    internal class LevenshteinFieldFilter<T> : ICollectionFilter where T : class
    {
        private readonly Func<T, string> _stringFieldChoose;
        private readonly LevenshteinFilter _levenshteinFilter;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requiredOverlap">Необходимое кол-во совподений для попадания в подходящие значения.</param>
        public LevenshteinFieldFilter(int requiredOverlap, Func<T, string> stringFieldChoose)
        {
            _levenshteinFilter = new LevenshteinFilter(requiredOverlap);
            _stringFieldChoose = stringFieldChoose;
        }

        /// <summary>
        /// Фитльтрация.
        /// Если класс внутри collection не явялется T, то он пропускается.
        /// </summary>
        /// <param name="collection">Коллекция для фильтрации.</param>
        /// <param name="pattern">Текстовый шаблон для фильтрации.</param>
        /// <returns></returns>
        public IEnumerable UseFilter(IEnumerable collection, string pattern)
        {
            var filteredPersons = FilterPersons(collection, pattern);
            return filteredPersons;
        }

        public IEnumerable FilterPersons(IEnumerable collection, string pattern)
        {
            var filteredPersons = new List<T>();

            foreach(var item in collection)
            {
                var itemT = item as T;
                if(itemT != null)
                {
                    if(_levenshteinFilter.LevenshteinWord(_stringFieldChoose.Invoke(itemT), pattern))
                    {
                        filteredPersons.Add(itemT);
                    }
                }
            }

            return filteredPersons;
        }
    }
}
