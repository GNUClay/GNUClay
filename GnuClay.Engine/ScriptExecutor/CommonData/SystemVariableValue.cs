using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class SystemVariableValue : IValue
    {
        public SystemVariableValue(IValue value)
        {
            ValueFromContainer = value;
        }

        private IValue mValue = null;
        public KindOfValue Kind { get; private set; } = KindOfValue.Undefined;
        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
        public bool IsProperty => false;

        public bool IsVariable => true;
        public bool IsSystemVariable => false;
        public bool IsValueContainer => true;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        public bool IsFact => false;
        public bool IsArray => false;

        public ulong GetLongHashCode()
        {
            return mValue.GetLongHashCode();
        }

        public IValue ValueFromContainer
        {
            get
            {
                return mValue;
            }

            set
            {
                if (mValue == value)
                {
                    return;
                }

                mValue = value;
                TypeKey = mValue.TypeKey;
                IsNull = mValue.IsNull;
                Kind = mValue.Kind;
            }
        }

        public bool IsNull { get; private set; }

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
            var nextIndent = indent + 4;
            var tmpSb = new StringBuilder($"{spacesString}SystemVariable ");

            if (mValue == null)
            {
                tmpSb.Append("Value = null");
            }
            else
            {
                tmpSb.Append($"Value = {mValue.ToString(dataDictionary, nextIndent)}");
            }

            return tmpSb.ToString();
        }

        public IExternalValue ToExternalValue()
        {
            var externalValue = new ExternalValue();
            externalValue.TypeKey = mValue.TypeKey;
            if (mValue.Kind == KindOfValue.Value)
            {
                externalValue.Kind = ExternalValueKind.Value;
                externalValue.Value = mValue.Value;
            }
            else
            {
                externalValue.Kind = ExternalValueKind.Entity;
            }

            return externalValue;
        }
    }
}
