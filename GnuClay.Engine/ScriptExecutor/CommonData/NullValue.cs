using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class NullValue: IValue
    {
        public NullValue(ulong typeKey)
        {
            TypeKey = typeKey;
        }

        public KindOfValue Kind => KindOfValue.Value;
        public ulong TypeKey { get; private set; }
        public object Value => null;
        public bool IsProperty => false;
        public bool IsVariable => false;
        public bool IsValueContainer => false;
        public IValue ValueFromContainer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsNull => true;
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => true;
        public bool IsFact => false;
        public bool IsArray => false;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        public ulong GetLongHashCode()
        {
            return TypeKey;
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"NullValue {nameof(TypeKey)} = {TypeKey}";
        }
    }
}
