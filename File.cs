using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WordsCounterTestTask.Interfaces;

namespace WordsCounterTestTask
{
   public class File : IFile
    {
        private readonly string _path;
        
        public File(string path)
        {
            this._path = path;
        }

        public async Task<List<string>> FileProcessing()
        {            
            List<string> lines = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(_path))
                {                    
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
            
        
    }
}
