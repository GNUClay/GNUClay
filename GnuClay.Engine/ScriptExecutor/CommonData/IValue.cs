using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public interface IValue
    {
        ITryCallResult TryCall(int key, List<IValue> args);
        ITryCallResult TrySetProperty(int key, IValue value);
    }
}
