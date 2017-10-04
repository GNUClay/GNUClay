using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
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
    [Serializable]
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
        public bool IsSystemVariable => false;
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
            return ToString(null, 0);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var nextIndent = indent + 4;
            var tmpSb = new StringBuilder($"{spacesString}SystemPropertyValue {nameof(Kind)}= {Kind};");
            if (mHolder == null)
            {
                tmpSb.Append("Holder = null;");
            }
            else
            {
                tmpSb.Append($"Holder = {mHolder.ToString(dataDictionary, nextIndent)};");
            }

            tmpSb.Append($"PropertyKey = {mPropertyKey};");

            if(dataDictionary != null && mPropertyKey > 0)
            {
                tmpSb.Append($"PropertyName = {dataDictionary.GetValue(mPropertyKey)};");
            }

            return tmpSb.ToString();
        }

        public IExternalValue ToExternalValue()
        {
            var externalValue = new ExternalValue();

            var tmpValue = ValueFromContainer;

            externalValue.TypeKey = tmpValue.TypeKey;
            if (tmpValue.Kind == KindOfValue.Value)
            {
                externalValue.Kind = ExternalValueKind.Value;
                externalValue.Value = tmpValue.Value;
            }
            else
            {
                externalValue.Kind = ExternalValueKind.Entity;
            }

            return externalValue;
        }
    }
}
