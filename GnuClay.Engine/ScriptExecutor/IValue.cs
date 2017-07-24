using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public interface IValue : ILongHashableObject
    {
        KindOfValue Kind { get; }
        ulong TypeKey { get; }
        void ExecuteSetLogicalProperty(PropertyAction action);
        void ExecuteGetLogicalProperty(PropertyAction action);
    }
}
