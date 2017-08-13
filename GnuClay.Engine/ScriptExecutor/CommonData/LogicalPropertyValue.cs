using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class LogicalPropertyValue : IValue
    {
        public LogicalPropertyValue(ulong typeKey, IValue holder, ulong propertyKey, GnuClayEngineComponentContext context)
        {
            TypeKey = typeKey;
            mHolder = holder;
            mPropertyKey = propertyKey;
            mContect = context;
            mLogicalStorage = mContect.LogicalStorage;
        }

        private GnuClayEngineComponentContext mContect = null;
        private LogicalStorageEngine mLogicalStorage = null;

        private IValue mHolder = null;
        private ulong mPropertyKey = 0;

        public KindOfValue Kind => KindOfValue.Logical;
        public ulong TypeKey { get; private set; }
        public object Value => throw new NotImplementedException();
        public bool IsProperty => true;
        public bool IsVariable => false;
        public bool IsValueContainer => true;
        public bool IsFact => false;
        public IValue ValueFromContainer
        {
            get
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ValueFromContainer get IS NOT IMPLEMENTED YET");
#endif
                //throw new NotImplementedException();

#if DEBUG
                return new EntityValue(15);
#endif
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
            return $"LogicalPropertyValue {nameof(TypeKey)} = {TypeKey}; {nameof(Kind)}= {Kind}; Holder = {mHolder}; PropertyKey = {mPropertyKey}";
        }
    }
}
