using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class LogicalProcessFactoryWithCommonClassFactory<T, C> : LogicalProcessFactory<T>
        where T : ILogicalProcessWithCommonClass<C>, new()
        where C : ICommonClassOfLogicalProcesses
    {
        public LogicalProcessFactoryWithCommonClassFactory(IContextOfLogicalProcesses context, C instanceOfCommonClass)
            : base(context)
        {
        }
    }
}
