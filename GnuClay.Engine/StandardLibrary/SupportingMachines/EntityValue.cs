using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    [Serializable]
    public class EntityValue : IValue
    {
        public EntityValue(ulong typeKey)
        {
            TypeKey = typeKey;
        }

        public KindOfValue Kind => KindOfValue.Logical;
        public ulong TypeKey { get; private set; }
        public object Value { get { throw new NotSupportedException(); } }
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
            return ToString(null, 0);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var sb = new StringBuilder($"{spacesString}EntityValue {nameof(TypeKey)} = {TypeKey};");

            if (dataDictionary != null && TypeKey > 0)
            {
                sb.Append($"TypeName = {dataDictionary.GetValue(TypeKey)};");
            }

            return sb.ToString();
        }

        public IExternalValue ToExternalValue()
        {
            var externalValue = new ExternalValue();
            externalValue.Kind = ExternalValueKind.Entity;
            externalValue.TypeKey = TypeKey;
            return externalValue;
        }
    }
}
