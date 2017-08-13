using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class BaseFactValue : IValue
    {
        protected BaseFactValue(ulong typeKey, GnuClayEngineComponentContext context)
        {
            TypeKey = typeKey;
            mContect = context;
        }

        private GnuClayEngineComponentContext mContect = null;

        public KindOfValue Kind => KindOfValue.Logical;

        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
        public bool IsProperty => throw new NotImplementedException();
        public bool IsVariable => throw new NotImplementedException();
        public bool IsValueContainer => throw new NotImplementedException();
        public IValue ValueFromContainer { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsNull => throw new NotImplementedException();
        public bool IsUndefined => throw new NotImplementedException();
        public bool IsNullOrUndefined => throw new NotImplementedException();
        public bool IsFact => true;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        public ulong GetLongHashCode()
        {
            return TypeKey;
        }
    }
}
