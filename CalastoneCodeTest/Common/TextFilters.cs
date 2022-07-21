using CalastoneCodeTest.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalastoneCodeTest.Common
{
    public class TextFilters
    {
        public List<IWordFilters> WordFilters { get; set; }

        public TextFilters()
        {
            WordFilters = GetWordFilters();
        }
        public List<string> GetWordListFromFile()
        {
            char[] SpecialChar = new char[] { '\n', '\r', '!', '(', ')', '"', ':', '?', ':', ';', '\'', '@', '.', ',', '`' };
            string textFile = @"D:\WorkSpace\Calastone\CalastoneCodeTest\CalastoneCodeTest\Files\TextInput.txt";

            string fileData = File.ReadAllText(textFile);
            fileData = fileData.ReplaceAll(SpecialChar, ' ');

            return fileData.Split(' ').Where(x => x != string.Empty).ToList<string>();
        }

        internal List<string> GetFilteredWords()
        {
           var wordsResult= GetWordListFromFile();
           return ApplyFilters(wordsResult);
        }

        private List<string> ApplyFilters(List<string> wordsResult)
        {
            foreach (var filter in WordFilters)
            {
                wordsResult = filter.ApplyFilter(wordsResult);
            }
            return wordsResult;
        }

        private List<IWordFilters> GetWordFilters()
        {
            return new List<IWordFilters>()
            {
                new VowelFilter(),
                new LessThan3WordFilter(),
                new RemoveTWordFilter()
            };
        }
    }
}
