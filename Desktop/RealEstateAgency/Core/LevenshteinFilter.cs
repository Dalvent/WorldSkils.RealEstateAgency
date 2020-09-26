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
    /// Фильтр Левенштейна для слов.
    /// </summary>
    internal class LevenshteinFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requiredOverlap">Необходимое кол-во совподений для попадания в подходящие значения.</param>
        public LevenshteinFilter(int requiredOverlap)
        {
            RequiredOverlap = requiredOverlap;
        }

        public int RequiredOverlap { get; }

        /// <summary>
        /// Проверяет подходит ли слово по алгроритму Левеншейна.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public bool LevenshteinWord(string word, string pattern)
        {
            int overlapCount = 0;

            for(int i = 0; i < word.Length; i++)
            {
                if(pattern.Length <= i)
                    return false;

                if(word[i] == pattern[i])
                {
                    overlapCount++;
                }

                if(overlapCount >= RequiredOverlap)
                    return true;

            }

            return false;
        }
    }
}
