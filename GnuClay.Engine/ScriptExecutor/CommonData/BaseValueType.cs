using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public abstract class BaseValueType : IValue
    {
        protected BaseValueType(ulong typeKey, object value)
        {
            mTypeKey = typeKey;
            Value = value;
        }

        public KindOfValue Kind
        {
            get
            {
                return KindOfValue.Value;
            }
        }

        private ulong mTypeKey = 0;

        public ulong TypeKey
        {
            get
            {
                return mTypeKey;
            }
        }

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
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;

        protected object Value { get; private set; } = null;

        public virtual ulong GetLongHashCode()
        {
            var result = TypeKey;

            if (Value != null)
            {
                result ^= (ulong)Value.GetHashCode();
            }

            return result;
        }

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }
    }
}
