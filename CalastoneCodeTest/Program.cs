using CalastoneCodeTest.Common;
using CalastoneCodeTest.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalastoneCodeTest
{
    internal class Program
    {
        static readonly char[] SpecialChar = new char[] { '\n', '\r', '!', '(', ')', '"', ':', '?', ':', ';', '\'', '@', '.', ',', '`' };

        static void Main(string[] args)
        {
            List<string> wordsResult = GetWordListFromFile();
            //ReadFile(wordsResult);

            List<IWordFilters> filterList = GetWordFilters();

            foreach (var filter in filterList)
            {
                wordsResult = filter.ApplyFilter(wordsResult);
            }

            foreach (string word in wordsResult)
            {
                Console.Write(word + '-');
            }
            Console.ReadLine();
        }

        private static List<string> GetWordListFromFile()
        {
            string textFile = @"D:\WorkSpace\Calastone\CalastoneCodeTest\CalastoneCodeTest\Files\TextInput.txt";

            string fileData = File.ReadAllText(textFile);
            fileData = fileData.ReplaceAll(SpecialChar, ' ');

            return fileData.Split(' ').Where(x => x != string.Empty).ToList<string>();
        }

        private static List<IWordFilters> GetWordFilters()
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
