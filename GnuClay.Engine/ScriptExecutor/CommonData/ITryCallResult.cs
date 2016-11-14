using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public interface ITryCallResult
    {
        bool Success { get; }
        IValue Result { get; }
        IGnuClayScriptFunctor Functor { get; }
    }
}
