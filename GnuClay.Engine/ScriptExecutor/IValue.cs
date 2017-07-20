using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public interface IValue : ILongHashableObject
    {
        ulong TypeKey { get; }
    }
}
