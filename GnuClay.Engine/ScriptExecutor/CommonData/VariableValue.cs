using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class VariableValue : IValue
    {
        public VariableValue(IValue value)
        {
            ValueOfContainer = value;
        }

        private IValue mValue = null;
        private ulong mTypeKey = 0;
        private KindOfValue mKind = KindOfValue.Undefined;

        public KindOfValue Kind => mKind;

        public ulong TypeKey => mTypeKey;

        public bool IsProperty => false;

        public bool IsVariable => true;

        public bool IsValueContainer => true;

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
            return mValue.GetLongHashCode();
        }

        public IValue ValueOfContainer
        {
            get
            {
                return mValue;
            }

            set
            {
                if(mValue == value)
                {
                    return;
                }

                mValue = value;
                mTypeKey = mValue.TypeKey;
                mKind = mValue.Kind;
            }
        }

        public bool IsNull => throw new NotImplementedException();
        public bool IsUndefined => throw new NotImplementedException();
        public bool IsNullOrUndefined => throw new NotImplementedException();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"Variable Value = {mValue}";
        }
    }
}
