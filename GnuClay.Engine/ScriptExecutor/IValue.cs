using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public interface IValue : ILongHashableObject, ISmartToString
    {
        KindOfValue Kind { get; }
        ulong TypeKey { get; }
        object Value { get; }
        bool IsProperty { get; }
        bool IsVariable { get; }
        bool IsSystemVariable { get; }
        bool IsValueContainer { get; }
        IValue ValueFromContainer { get; set; }
        bool IsNull { get; }
        bool IsUndefined { get; }
        bool IsNullOrUndefined { get; }
        bool IsFact { get; }
        bool IsArray { get; }

        ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators);
        IExternalValue ToExternalValue();
    }
}
