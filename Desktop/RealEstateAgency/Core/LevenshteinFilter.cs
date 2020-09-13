using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    class LevenshteinPersonFilter : IPersonFilter
    {

        public LevenshteinPersonFilter(IList<IPersonInfo> targetList, int requiredOverlap)
        {
            TargetList = targetList;
            RequiredOverlap = requiredOverlap;
        }
        public IList<IPersonInfo> TargetList { get; set; }
        public int RequiredOverlap { get; set; }

        public IList<IPersonInfo> GetFilteredPersonInfos(string pattern)
        {
            var result = new List<IPersonInfo>();

            foreach (var item in TargetList)
            {
                if(LevenshteinPersonInfo(item, pattern))
                {
                    result.Add(item);
                }
            }

            return result;
        }

        private bool LevenshteinPersonInfo(IPersonInfo personInfo, string pattern)
        {
            return LevenshteinWord(personInfo.FirstName, pattern) ||
                LevenshteinWord(personInfo.LastName, pattern) ||
                LevenshteinWord(personInfo.MiddleName, pattern);
        }

        private bool LevenshteinWord(string word, string pattern)
        {
            int overlapCount = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if(overlapCount >= RequiredOverlap)  return true;
                if (pattern.Length <= i) return false;

                if(word[i] == pattern[i])
                {
                    overlapCount++;
                }
            }

            return false;
        }
    }
}
