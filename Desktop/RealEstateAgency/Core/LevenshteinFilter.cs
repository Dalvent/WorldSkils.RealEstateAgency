using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    /// <summary>
    /// Фильтр Левенштейна.
    /// </summary>
    internal class LevenshteinPersonFilter : IFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requiredOverlap">Необходимое кол-во совподений для попадания в подходящие значения.</param>
        public LevenshteinPersonFilter(int requiredOverlap)
        {
            RequiredOverlap = requiredOverlap;
        }

        /// <summary>
        /// Необходимое кол-во совподений для попадания в подходящие значения.
        /// </summary>
        public int RequiredOverlap { get; set; }
        public IList<object> Context { get; set; }

        public IList<object> GetFilteredPersonInfos(string pattern)
        {
            var result = new List<IPersonInfo>();

            foreach(IPersonInfo item in Context)
            {
                if(LevenshteinPersonInfo(item, pattern))
                {
                    result.Add(item);
                }
            }

            return (IList<object>)result;
        }

        /// <summary>
        /// Проверяет подходит ли любое слово из ФИО по алгроритму Левеншейна.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private bool LevenshteinPersonInfo(IPersonInfo personInfo, string pattern)
        {
            return LevenshteinWord(personInfo.FirstName, pattern) ||
                LevenshteinWord(personInfo.LastName, pattern) ||
                LevenshteinWord(personInfo.MiddleName, pattern);
        }

        /// <summary>
        /// Проверяет подходит ли слово по алгроритму Левеншейна.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private bool LevenshteinWord(string word, string pattern)
        {
            int overlapCount = 0;

            for(int i = 0; i < word.Length; i++)
            {
                if(overlapCount >= RequiredOverlap)
                    return true;
                if(pattern.Length <= i)
                    return false;

                if(word[i] == pattern[i])
                {
                    overlapCount++;
                }
            }

            return false;
        }
    }
}
