using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    public enum ExternalValueKind
    {
        Entity,
        Value
    }

    public interface IExternalValue : ISmartToString
    {
        ExternalValueKind Kind { get; }
        ulong TypeKey { get; }
        object Value { get; }
    }
}
