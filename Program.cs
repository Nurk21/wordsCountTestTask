using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordsCounterTestTask.Interfaces;

namespace WordsCounterTestTask
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string path = "";
            int result = 0;
            List<string> lines = new List<string>();
            Regex regex = new Regex(pattern: @"\b[aeiouy]+\b", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);            

            Console.WriteLine("Type the path to the text file in the following format: C:\\*.txt");

            do
            {
                path = Console.ReadLine();
                lines = await new File(path).FileProcessing();
            }
            while (lines.Count == 0);

            result = new FileService(lines, regex).processing();

            Console.WriteLine($"An input file has {result} words with wovels characters only") ;
            Console.ReadKey();
        }
    }
}
