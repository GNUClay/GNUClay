using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class PropertyValue : IValue
    {
        public PropertyValue(ulong typeKey, PropertyFilter targetExecutor, bool isLogical)
        {
            mTypeKey = typeKey;
            mTargetExecutor = targetExecutor;

            if(isLogical)
            {
                mKindOfValue = KindOfValue.Logical;
            }
            else
            {
                mKindOfValue = KindOfValue.System;
            }
        }

        private KindOfValue mKindOfValue = KindOfValue.Undefined;

        public KindOfValue Kind => mKindOfValue;

        private ulong mTypeKey = 0;

        public ulong TypeKey => mTypeKey;

        public bool IsProperty => true;

        private PropertyFilter mTargetExecutor = null;

        public void ExecuteGetLogicalProperty(PropertyAction action)
        {
            throw new NotImplementedException();
        }

        public void ExecuteSetLogicalProperty(PropertyAction action, KindOfLogicalOperator kindOfLogicalOperators)
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
            return $"PropertyValue {nameof(TypeKey)} = {TypeKey}; {nameof(Kind)}= {Kind}";
        }
    }
}
