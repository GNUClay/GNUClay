using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public interface INewConcreteTypeProvider
    {
        ulong TypeKey { get; }
        IValue CreateConstValue(ulong typeKey, object value);
    }
}
