using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
    public class LogicalPropertyValue : IValue
    {
        public LogicalPropertyValue(ulong typeKey, IValue holder, ulong propertyKey, GnuClayEngineComponentContext context)
        {
            TypeKey = typeKey;
            mHolder = holder;
            mPropertyKey = propertyKey;
            mContect = context;
            mLogicalStorage = mContect.LogicalStorage;
            mDataDictionary = mContect.DataDictionary;
            mCommonValuesFactory = mContect.CommonValuesFactory;
        }

        private GnuClayEngineComponentContext mContect = null;
        private LogicalStorageEngine mLogicalStorage = null;
        private StorageDataDictionary mDataDictionary = null;
        private CommonValuesFactory mCommonValuesFactory = null;

        private IValue mHolder = null;
        private ulong mPropertyKey = 0;

        public KindOfValue Kind => KindOfValue.Logical;
        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
        public bool IsProperty => true;
        public bool IsVariable => false;
        public bool IsValueContainer => true;
        public bool IsFact => false;
        public bool IsArray => true;
        public IValue ValueFromContainer
        {
            get
            {
                return ReadFactsReturnFitstFact();
            }

            set
            {
                ExecuteSetLogicalProperty(value, KindOfLogicalOperator.WriteFactReturnValue);
            }
        }

        public bool IsNull => false;
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
            var result = new ResultOfCalling();

            try
            {
                switch(kindOfLogicalOperators)
                {
                    case KindOfLogicalOperator.WriteFactReturnValue:
                        WriteFactReturnValue(value, result);
                        break;

                    case KindOfLogicalOperator.WriteFactReturnThisFact:
                        WriteFactReturnThisFact(value, result);
                        break;

                    case KindOfLogicalOperator.RewriteFactReturnValue:
                        RewriteFactReturnValue(value, result);
                        break;

                    case KindOfLogicalOperator.RewriteFactReturnThisFact:
                        RewriteFactReturnThisFact(value, result);
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(kindOfLogicalOperators), kindOfLogicalOperators, null);
                }
                
                result.Success = true;
            }
            catch(Exception e)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteSetLogicalProperty value = {value} kindOfLogicalOperators = {kindOfLogicalOperators} e = {e}");
#endif

                result.Success = false;
            }

            return result;
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

            var tmpSb = new StringBuilder($"{spacesString}LogicalPropertyValue {nameof(Kind)}= {Kind};");
            if (mHolder == null)
            {
                tmpSb.Append("Holder = null;");
            }
            else
            {
                tmpSb.Append($"Holder = {mHolder.ToString(dataDictionary, nextIndent)};");
            }

            tmpSb.Append($"PropertyKey = {mPropertyKey};");

            if (dataDictionary != null && mPropertyKey > 0)
            {
                tmpSb.Append($"PropertyName = {dataDictionary.GetValue(mPropertyKey)};");
            }

            return tmpSb.ToString();
        }

        private void WriteFactReturnValue(IValue value, ResultOfCalling resultOfCalling)
        {
            var targetFact = mLogicalStorage.SetLogicalProperty(mHolder, mPropertyKey, value, false);
            resultOfCalling.Result = value;
        }

        private void WriteFactReturnThisFact(IValue value, ResultOfCalling resultOfCalling)
        {
            var targetFact = mLogicalStorage.SetLogicalProperty(mHolder, mPropertyKey, value, false);
            resultOfCalling.Result = targetFact;
        }

        private void RewriteFactReturnValue(IValue value, ResultOfCalling resultOfCalling)
        {
            var targetFact = mLogicalStorage.SetLogicalProperty(mHolder, mPropertyKey, value, true);
            resultOfCalling.Result = value;
        }

        private void RewriteFactReturnThisFact(IValue value, ResultOfCalling resultOfCalling)
        {
            var targetFact = mLogicalStorage.SetLogicalProperty(mHolder, mPropertyKey, value, true);
            resultOfCalling.Result = targetFact;
        }

        private IValue ReadFactsReturnFitstFact()
        {
            var selectResult = mLogicalStorage.GetLogicalPropery(mHolder, mPropertyKey);

            if(!selectResult.Success || !selectResult.HaveBeenFound || selectResult.Items.Count == 0)
            {
                return mCommonValuesFactory.NullValue();
            }

            var targetItem = selectResult.Items.First();
            return new FactValue(targetItem.Key, selectResult, mContect);
        }
    }
}
