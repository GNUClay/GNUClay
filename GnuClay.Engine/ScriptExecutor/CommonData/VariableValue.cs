using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
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
            ValueFromContainer = value;
        }

        private IValue mValue = null;
        private ulong mTypeKey = 0;
        private KindOfValue mKind = KindOfValue.Undefined;

        public KindOfValue Kind => mKind;

        public ulong TypeKey => mTypeKey;
        public object Value => throw new NotImplementedException();
        public bool IsProperty => false;

        public bool IsVariable => true;

        public bool IsValueContainer => true;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        public bool IsFact => false;
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
                if(mValue == value)
                {
                    return;
                }

                mValue = value;
                mTypeKey = mValue.TypeKey;
                mKind = mValue.Kind;
            }
        }

        public bool IsNull => false;
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;

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
