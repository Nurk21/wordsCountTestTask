using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordsCounterTestTask.Services
{
    public interface IFileService
    {
        int Processing(List<string> lines, Regex regex);
        Task<List<string>> LoadDataAsync(string path);
    }
    public class FileService : IFileService
    {

        public async Task<List<string>> LoadDataAsync(string path)
        {
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                { 
                    if (File.Exists(path) && sr.Peek() == -1)
                    {
                        throw new Exception("File is Empty");
                    }
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }
                }
                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Try again");
            }
            return lines;
        }
        public int Processing(List<string> lines, Regex regex)
        {
            // Эта часть кода выводит считываемый файл на консоль для удобства проверки результата
            //
            //foreach (string line in lines)
            //{
            //    Console.WriteLine(line);
            //}
            //Console.WriteLine("-----------------------------------------------------------");

            int result = 0;
            foreach (string line in lines)
            {

                MatchCollection matches = regex.Matches(line);
                if (matches.Count > 0)
                {
                    result += matches.Count;
                }
            }
            return result;
        }
    }
}
