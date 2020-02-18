using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordsCounterTestTask.Interfaces
{
    public interface IFile
    {
         Task<List<string>> FileProcessing();
    }
}
