using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public enum NewEntityActionState
    {
        Init,
        Running,
        Completed,
        Faulted,
        Canceled
    }
}
