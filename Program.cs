using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCounterTestTask
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int result = 0;            
            string path;            
            List<string> lines = new List<string>();
            List<string> words = new List<string>();
            bool pointer = false;
            do
            {
                Console.WriteLine("Type the path to the text file in the following format: C:\\*.txt");
                path = Console.ReadLine();
                
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string line;
                        while ((line = await sr.ReadLineAsync())!= null)
                        {
                            lines.Add(line);                            
                        }
                    }
                    pointer = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Try again");
                }
            }
            while (pointer == false);
            //Regex regex = new Regex(pattern: @"\w*", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //foreach (string line in lines)
            //{
            //    MatchCollection matches = regex.Matches(line);
            //        if (matches.Count > 0)
            //        {
            //        foreach (Match match in matches)
            //            words.Add(match.Value);
            //        }

            //}

            //Regex regex1 = new Regex(pattern: @"\A[eyuioa]+(\s|\z|\Z|\n)", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //foreach (string word in words)
            //    {
            //        Console.WriteLine(word);
            //    }
            //    foreach (string word in words)
            //    {

            //        MatchCollection matches = regex1.Matches(word);
            //        if (matches.Count > 0)
            //        {
            //            foreach (Match match in matches)
            //                result += matches.Count;
            //        }
            //    }

                Regex regex = new Regex(pattern: @"\b[aeiouy]+\b", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.WriteLine("-----------------------------------------------------------");

                foreach (string line in lines)
                {

                    MatchCollection matches = regex.Matches(line);
                    if (matches.Count > 0)
                    {
                    result += matches.Count;
                    }
                }


                Console.WriteLine($"An input file has {result} words with wovels characters only") ;
            Console.ReadKey();
        }
    }
}
