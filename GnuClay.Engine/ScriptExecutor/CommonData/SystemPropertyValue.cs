using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class SystemPropertyValue : IValue
    {
        public SystemPropertyValue(ulong typeKey, PropertyFilter targetExecutor, IValue holder, GnuClayEngineComponentContext context)
        {
            mTypeKey = typeKey;
            mTargetExecutor = targetExecutor;
            mHolder = holder;
            mContect = context;
        }

        private GnuClayEngineComponentContext mContect = null;
        private IValue mHolder = null;

        public KindOfValue Kind => KindOfValue.System;

        private ulong mTypeKey = 0;

        public ulong TypeKey => mTypeKey;

        public bool IsProperty => true;
        public bool IsVariable => false;
        public bool IsValueContainer => true;
        public IValue ValueFromContainer
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public bool IsNull => false;
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;

        private PropertyFilter mTargetExecutor = null;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        public ulong GetLongHashCode()
        {
            return mTypeKey;
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"SystemPropertyValue {nameof(TypeKey)} = {TypeKey}; {nameof(Kind)}= {Kind}; Holder = {mHolder}";
        }
    }
}
