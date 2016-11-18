using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public interface IValue
    {
        int TypeKey { get; }
        object ToExternal();
        ITryCallResult TryCall(int key, List<IValue> args);
        ITryCallPropertyResult TrySetProperty(int key, IValue value);
    }
}
