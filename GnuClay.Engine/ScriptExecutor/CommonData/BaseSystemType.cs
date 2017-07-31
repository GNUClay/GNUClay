using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public abstract class BaseSystemType : IValue
    {
        protected BaseSystemType(ulong typeKey)
        {
            mTypeKey = typeKey;
        }

        public KindOfValue Kind => KindOfValue.System;

        private ulong mTypeKey = 0;

        public ulong TypeKey => mTypeKey;

        public bool IsProperty => false;

        public bool IsVariable => false;

        public bool IsValueContainer => false;

        public abstract ulong GetLongHashCode();

        public void ExecuteSetLogicalProperty(PropertyAction action, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        public void ExecuteGetLogicalProperty(PropertyAction action)
        {
            throw new NotImplementedException();
        }
    }
}
