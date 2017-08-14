using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class SystemPropertyValue : IValue
    {
        public SystemPropertyValue(ulong typeKey, PropertyFilter targetExecutor, IValue holder, GnuClayEngineComponentContext context)
        {
            TypeKey = typeKey;
            mTargetExecutor = targetExecutor;
            mHolder = holder;
            mPropertyKey = mTargetExecutor.PropertyKey;
            mContect = context;
            mPropertiesEngine = mContect.PropertiesEngine;
        }

        private GnuClayEngineComponentContext mContect = null;
        private PropertiesEngine mPropertiesEngine = null;
        private IValue mHolder = null;
        private ulong mPropertyKey = 0;

        public KindOfValue Kind => KindOfValue.System;
        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
        public bool IsProperty => true;
        public bool IsVariable => false;
        public bool IsValueContainer => true;
        public IValue ValueFromContainer
        {
            get
            {
                var command = mPropertiesEngine.CreateGetCommand(mHolder, mPropertyKey);
                var propertyAction = mPropertiesEngine.CreatePropertyAction(command);
                mPropertiesEngine.CallSystemProperty(mHolder, mTargetExecutor.GetMethod, propertyAction);

                if(propertyAction.State == EntityActionState.Completed)
                {
                    return propertyAction.Result;
                }

                throw new InternalCallException(propertyAction.Error);
            }

            set
            {
                var command = mPropertiesEngine.CreateSetCommand(mHolder, mPropertyKey, value);
                var propertyAction = mPropertiesEngine.CreatePropertyAction(command);
                mPropertiesEngine.CallSystemProperty(mHolder, mTargetExecutor.SetMethod, propertyAction);
            }
        }

        public bool IsNull => false;
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;
        public bool IsFact => false;
        public bool IsArray => false;

        private PropertyFilter mTargetExecutor = null;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            throw new NotImplementedException();
        }

        public ulong GetLongHashCode()
        {
            return TypeKey;
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
