using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalastoneCodeTest.Filters
{
    public class VowelFilter : IWordFilters
    {
        public List<string> ApplyFilter(List<string> wordList)
        {
            string[] VowelChar = new string[] { "a", "e", "i", "o", "u" };

            List<string> VowelFilter = new List<string>();
            foreach (string word in wordList)
            {
                var offset = word.Length % 2 == 0 ? 1 : 0;
                var middle = word.Substring(word.Length / 2 - offset, offset + 1);
                if (VowelChar.Contains(middle.ToLower()) && word.Length > 1)
                {
                    VowelFilter.Add(word);
                }
            }

            List<string> filterResult = wordList.Except(VowelFilter).ToList();
            return filterResult;
        }
    }
}
