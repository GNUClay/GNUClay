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
        T InstanceOfCommonClass { get; set; }
    }

    public class LogicalProcessWithCommonClass<T>: LogicalProcess, ILogicalProcessWithCommonClass<T>
        where T: ICommonClassOfLogicalProcesses
    {
        public LogicalProcessWithCommonClass(LogicalProcessOptions options)
            : base(options)
        {
        }

        private T mInstanceOfCommonClass = default(T);

        public T InstanceOfCommonClass
        {
            get
            {
                return mInstanceOfCommonClass;
            }

            set
            {
                mInstanceOfCommonClass = value;
                Context = mInstanceOfCommonClass.Context;
            }
        }
    }
}
