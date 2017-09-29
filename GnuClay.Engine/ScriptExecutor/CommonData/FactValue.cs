using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
    public class FactValue : IValue
    {
        public FactValue(ulong typeKey, GnuClayEngineComponentContext context)
            : this(typeKey, null, context)
        {
        }

        public FactValue(ulong typeKey, SelectResult selctResult, GnuClayEngineComponentContext context)
        {
            mContect = context;
            mDataDictionary = mContect.DataDictionary;

            TypeKey = typeKey;
            mSelectResult = selctResult;

            if(TypeKey > 0)
            {
                IsDirectFact = true;
            }
        }

        private GnuClayEngineComponentContext mContect = null;
        private StorageDataDictionary mDataDictionary = null;

        private SelectResult mSelectResult = null;
        private bool IsDirectFact = false;

        public KindOfValue Kind => KindOfValue.Value;
        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
        public bool IsProperty => false;
        public bool IsVariable => false;
        public bool IsSystemVariable => false;
        public bool IsValueContainer => false;
        public IValue ValueFromContainer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsNull => false;
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;
        public bool IsFact => true;
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
            var nextIndent = indent + 4;

            var sb = new StringBuilder($"{spacesString}FactValue {nameof(TypeKey)} = { TypeKey}; {nameof(IsDirectFact)}= {IsDirectFact}; ");

            if (!IsDirectFact)
            {
                sb.Append(SelectResultDebugHelper.ConvertToString(mSelectResult, mDataDictionary));
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
