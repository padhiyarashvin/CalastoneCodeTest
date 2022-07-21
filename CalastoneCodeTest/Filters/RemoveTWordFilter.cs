using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalastoneCodeTest.Filters
{
    public class RemoveTWordFilter : IWordFilters
    {
        public List<string> ApplyFilter(List<string> wordList)
        {
            List<string> filterList = wordList.Where(x => x.ToLower().Contains('t')).Distinct().ToList<string>();
            List<string> filterResult = wordList.Except(filterList).ToList();
            return filterResult;
        }
    }
}
