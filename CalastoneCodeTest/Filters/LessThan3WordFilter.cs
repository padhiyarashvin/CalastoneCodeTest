using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalastoneCodeTest.Filters
{
    public class LessThan3WordFilter : IWordFilters
    {
        public List<string> ApplyFilter(List<string> wordList)
        {
            List<string> filterList = wordList.Where(x => x.Length < 3 && x != String.Empty).Distinct().ToList<string>();
            List<string> filterResult = wordList.Except(filterList).ToList();
            return filterResult;
        }
    }

}
