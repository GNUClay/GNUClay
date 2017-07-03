using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public enum KindOfFunction
    {
        Undefined,
        UserDefined,
        Remote,
        Threaded
    }

    public enum KindOfCall
    {
        Sync,
        Async
    }

    public class NewResultOfCalling
    {
    }
}
