using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public interface ILogicalProcessWithCommonClass<T>: ILogicalProcess
        where T : ICommonClassOfLogicalProcesses
    {

    }

    public class LogicalProcessWithCommonClass<T>: LogicalProcess, ILogicalProcessWithCommonClass<T>
        where T: ICommonClassOfLogicalProcesses
    {
        public LogicalProcessWithCommonClass(LogicalProcessOptions options)
            : base(options)
        {
        }


    }
}
