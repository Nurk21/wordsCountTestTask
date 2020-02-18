using System;
using System.Text.RegularExpressions;
using WordsCounterTestTask.Entities;
using WordsCounterTestTask.Services;

namespace WordsCounterTestTask
{
    class Program
    {
        public static void Main(string[] args)
        {
            var file = new DataFile();
            IFileService _fileService = new FileService();
            Regex regex = new Regex(pattern: @"\b[aeiouy]+\b", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

            Console.WriteLine("Type the path to the text file in the following format: C:\\*.txt");

            do
            {
                file.Path = Console.ReadLine();
                file.Lines = _fileService.LoadDataAsync(file.Path).Result;
            }
            while (file.Lines.Count == 0);

            var result = _fileService.Processing(file.Lines, regex);

            Console.WriteLine($"An input file has {result} words with wovels characters only");
            Console.ReadKey();
        }
    }
}
