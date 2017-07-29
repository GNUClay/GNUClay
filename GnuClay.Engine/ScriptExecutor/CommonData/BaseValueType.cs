using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public abstract class BaseValueType : IValue
    {
        protected BaseValueType(ulong typeKey, object value)
        {
            mTypeKey = typeKey;
            Value = value;
        }

        public KindOfValue Kind
        {
            get
            {
                return KindOfValue.Value;
            }
        }

        private ulong mTypeKey = 0;

        public ulong TypeKey
        {
            get
            {
                return mTypeKey;
            }
        }

        protected object Value { get; private set; } = null;

        public virtual ulong GetLongHashCode()
        {
            var result = TypeKey;

            if (Value != null)
            {
                result ^= (ulong)Value.GetHashCode();
            }

            return result;
        }

        public void ExecuteSetLogicalProperty(PropertyAction action, KindOfLogicalOperator kindOfLogicalOperators)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteSetLogicalProperty action = {action} kindOfLogicalOperators = {kindOfLogicalOperators}");
#endif
            //throw new NotImplementedException();
        }

        public void ExecuteGetLogicalProperty(PropertyAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteGetLogicalProperty action = {action}");
#endif
            //throw new NotImplementedException();
        }
    }
}
