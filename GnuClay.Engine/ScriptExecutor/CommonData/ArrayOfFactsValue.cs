using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.InternalCommonData;
using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.LogicalStorage.DebugHelpers;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class ArrayOfFactsValue: IValue
    {
        public ArrayOfFactsValue(ulong typeKey, SelectResult selectResult, GnuClayEngineComponentContext context)
        {
            TypeKey = typeKey;
            mSelectResult = selectResult;
            mContect = context;
        }

        private SelectResult mSelectResult = null;
        private GnuClayEngineComponentContext mContect = null;

        public KindOfValue Kind => KindOfValue.Value;
        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
        public bool IsProperty => false;
        public bool IsVariable => false;
        public bool IsValueContainer => true;
        public IValue ValueFromContainer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsNull => false;
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;
        public bool IsFact => true;
        public bool IsArray => true;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        public ulong GetLongHashCode()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"ArrayOfFactsValue {nameof(TypeKey)} = {TypeKey}; {nameof(Kind)}= {Kind}; {SelectResultDebugHelper.ConvertToString(mSelectResult, mContect.DataDictionary)}";
        }
    }
}
