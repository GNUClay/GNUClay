using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public interface IConcreteTypeProvider
    {
        ulong TypeKey { get; }
        IValue CreateConstValue(ulong typeKey, object value);
    }
}
