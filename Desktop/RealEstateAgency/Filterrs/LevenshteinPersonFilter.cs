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
    /// Фильтр Левенштейна для класса Person.
    /// </summary>
    internal class LevenshteinPersonFilter : ICollectionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requiredOverlap">Необходимое кол-во совподений для попадания в подходящие значения.</param>
        public LevenshteinPersonFilter(int requiredOverlap)
        {
            levenshteinFilter = new LevenshteinFilter(requiredOverlap);
        }

        /// <summary>
        /// Необходимое кол-во совподений для попадания в подходящие значения.
        /// </summary>
        private LevenshteinFilter levenshteinFilter;
        public IEnumerable UseFilter(IEnumerable collection, string pattern)
        {
            var filteredPersons = FilterPersons(collection, pattern);
            return filteredPersons;
        }

        public IEnumerable FilterPersons(IEnumerable persons, string pattern)
        {
            var filteredPersons = new List<Person>();

            foreach(Person item in persons)
            {
                if(LevenshteinPersonInfo(item, pattern))
                {
                    filteredPersons.Add(item);
                }
            }

            return filteredPersons;
        }

        /// <summary>
        /// Проверяет подходит ли любое слово из ФИО по алгроритму Левеншейна.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private bool LevenshteinPersonInfo(Person personInfo, string pattern)
        {
            return levenshteinFilter.LevenshteinWord(personInfo.FirstName, pattern) ||
                levenshteinFilter.LevenshteinWord(personInfo.LastName, pattern) ||
                levenshteinFilter.LevenshteinWord(personInfo.MiddleName, pattern);
        }
    }
}
