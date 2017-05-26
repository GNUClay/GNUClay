using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public interface IContextOfLogicalProcesses
    {
        void AddFilter(CommandFilter filter);
        ulong GetKey(string val);
    }
}
