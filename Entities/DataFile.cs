using System.Collections.Generic;

namespace WordsCounterTestTask.Entities
{
    public class DataFile
    {
        public string Path { get; set; }
        public List<string> Lines { get; set; }
    }
}
