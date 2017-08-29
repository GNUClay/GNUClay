using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
    public class UndefinedValue: IValue
    {
        public UndefinedValue(ulong typeKey)
        {
            TypeKey = typeKey;
        }

        public KindOfValue Kind => KindOfValue.Value;
        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
        public bool IsProperty => false;
        public bool IsVariable => false;
        public bool IsValueContainer => false;
        public IValue ValueFromContainer
        {
            get
            {
                return this;
            }

            set
            {
                throw new NotSupportedException();
            }
        }

        public bool IsNull => false;
        public bool IsUndefined => true;
        public bool IsNullOrUndefined => true;
        public bool IsFact => false;
        public bool IsArray => false;

        public ulong GetLongHashCode()
        {
            return TypeKey;
        }

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"UndefinedValue {nameof(TypeKey)} = {TypeKey}";
        }
    }
}
