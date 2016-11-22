using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public interface IGnuClayAbstractProperty
    {
        bool Probing(IValue arg);
        IValue Set(object obj, IValue arg);
        IValue Get(object obj);
    }
}
