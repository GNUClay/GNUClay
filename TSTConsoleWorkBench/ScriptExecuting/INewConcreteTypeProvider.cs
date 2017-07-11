using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public interface INewConcreteTypeProvider
    {
        INewValue CreateConstValue(ulong typeKey, object value);
    }
}
