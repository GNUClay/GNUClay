using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class UnknownWordException: Exception
    {
        public UnknownWordException(string word)
            : base($"Unknown word `{word}`")
        {
        }
    }
}
