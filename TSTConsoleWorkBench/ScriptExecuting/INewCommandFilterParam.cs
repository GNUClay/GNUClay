using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public interface INewCommandFilterParam: INewLongHashableObject
    {
        bool IsAnyType { get; set; }
        ulong TypeKey { get; set; }
        bool IsAnyValue { get; set; }
        INewValue Value { get; set; }
    }
}
