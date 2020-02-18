using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WordsCounterTestTask
{
    public class FileService
    {
        private List<string> _lines;
        private Regex _regex;
        public FileService(List<string> lines, Regex regex)
        {
            this._lines = lines;
            this._regex = regex;
        }
        public int processing()
        {
            int result = 0;
            foreach (string line in _lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("-----------------------------------------------------------");

            foreach (string line in _lines)
            {

                MatchCollection matches = _regex.Matches(line);
                if (matches.Count > 0)
                {
                    result += matches.Count;
                }
            }
            return result;
        }
    }
}
