using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public interface IGnuClayScriptFunctor
    {
        bool Probing(List<IValue> args);
        IValue Invoke(object obj, List<IValue> args);
    }
}
