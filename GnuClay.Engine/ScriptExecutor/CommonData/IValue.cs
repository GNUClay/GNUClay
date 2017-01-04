using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public interface IValue
    {
        ulong TypeKey { get; }
        object ToExternal();
        ITryCallResult TryCall(ulong key, List<IValue> args);
        ITryCallPropertyResult TrySetProperty(ulong key, IValue value);
        ITryCallPropertyResult TryGetProperty(ulong key);
    }
}
