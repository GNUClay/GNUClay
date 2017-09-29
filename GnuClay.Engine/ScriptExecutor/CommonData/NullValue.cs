using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.CommonClientTypes.CommonData;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
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
        public bool IsSystemVariable => false;
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
            return $"{spacesString}NullValue";
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
