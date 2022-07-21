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
        static void Main(string[] args)
        {
            TextFilters textFilters = new TextFilters();
            var wordsResult = textFilters.GetFilteredWords();
            
            foreach (string word in wordsResult)
            {
                Console.WriteLine(word);
            }

            Console.ReadLine();
        }        
    }
}
