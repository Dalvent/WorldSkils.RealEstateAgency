﻿using RealEstateAgency.Data;
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
        public IList<T> Filter<T>(IList<T> collection, string pattern)
        {
            if(!typeof(T).IsSubclassOf(typeof(Person)))
            {
                throw new ArgumentException($"LevenshteinPersonFilter can filtered only person subclasses.");
            }

            var filteredPersons = FilterPersons(collection.Cast<Person>().ToList(), pattern);
            return filteredPersons.Cast<T>().ToList();
        }

        public IList<Person> FilterPersons(IList<Person> persons, string pattern)
        {
            IList<Person> filteredPersons = new List<Person>();

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
