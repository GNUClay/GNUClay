using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class EntityValue : IValue
    {
        public EntityValue(ulong typeKey)
        {
            mTypeKey = typeKey;
        }

        public KindOfValue Kind => KindOfValue.Logical;

        private ulong mTypeKey = 0;

        public ulong TypeKey => mTypeKey;
        public object Value { get { throw new NotSupportedException(); } }
        public bool IsProperty => false;
        public bool IsVariable => false;
        public bool IsValueContainer => false;
        public IValue ValueFromContainer
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
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;
        public bool IsFact => false;

        public ulong GetLongHashCode()
        {
            return mTypeKey;
        }

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"EntityValue {nameof(TypeKey)} = {TypeKey}";
        }
    }
}
