using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class UndefinedValue: IValue
    {
        public UndefinedValue(ulong typeKey)
        {
            mTypeKey = typeKey;
        }

        public KindOfValue Kind => KindOfValue.Value;

        private ulong mTypeKey = 0;

        public ulong TypeKey => mTypeKey;

        public bool IsProperty => false;
        public bool IsVariable => false;
        public bool IsValueContainer => false;
        public IValue ValueOfContainer
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
        public bool IsUndefined => true;
        public bool IsNullOrUndefined => true;

        public ulong GetLongHashCode()
        {
            return mTypeKey;
        }

        public void ExecuteSetLogicalProperty(PropertyAction action, KindOfLogicalOperator kindOfLogicalOperators)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteSetLogicalProperty action = {action} kindOfLogicalOperators = {kindOfLogicalOperators}");
#endif
            throw new NotImplementedException();
        }

        public void ExecuteGetLogicalProperty(PropertyAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteGetLogicalProperty action = {action}");
#endif
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"UndefinedValue {nameof(TypeKey)} = {TypeKey}";
        }
    }
}
