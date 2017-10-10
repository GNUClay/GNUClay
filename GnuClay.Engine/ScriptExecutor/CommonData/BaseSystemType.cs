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
    public abstract class BaseSystemType : IValue
    {
        protected BaseSystemType(ulong typeKey)
        {
            TypeKey = typeKey;
        }

        public KindOfValue Kind => KindOfValue.System;
        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
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
        public bool IsArray => false;

        /// <summary>
        /// Serves as the hash function that has size as ulong.
        /// </summary>
        /// <returns>Return value of the hash.</returns>
        public abstract ulong GetLongHashCode();

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
            externalValue.Kind = ExternalValueKind.Entity;
            externalValue.TypeKey = TypeKey;
            return externalValue;
        }
    }
}
