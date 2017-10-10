using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
    public abstract class BaseValueType : IValue
    {
        protected BaseValueType(ulong typeKey, object value)
        {
            TypeKey = typeKey;
            Value = value;
        }

        public KindOfValue Kind
        {
            get
            {
                return KindOfValue.Value;
            }
        }
        public ulong TypeKey { get; private set; }
        public bool IsProperty => false;
        public bool IsVariable => false;
        public bool IsSystemVariable => false;
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
        public bool IsFact => false;
        public object Value { get; private set; } = null;
        public bool IsArray => false;

        /// <summary>
        /// Serves as the hash function that has size as ulong.
        /// </summary>
        /// <returns>Return value of the hash.</returns>
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

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public abstract string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent);
        public IExternalValue ToExternalValue()
        {
            var externalValue = new ExternalValue();
            externalValue.Kind = ExternalValueKind.Value;
            externalValue.TypeKey = TypeKey;
            externalValue.Value = Value;
            return externalValue;
        }
    }
}
