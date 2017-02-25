using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public interface IPhrase
    {
        IPhrase Clone(Dictionary<object, object> ptrList);
        string ToDbgString();
    }
}
