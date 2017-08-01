﻿using GnuClay.Engine.InternalCommonData;
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
        public LogicalPropertyValue(ulong typeKey, IValue holder, GnuClayEngineComponentContext context)
        {
            mTypeKey = typeKey;
            mHolderKey = holder.TypeKey;
            mContect = context;
        }

        private GnuClayEngineComponentContext mContect = null;
        private ulong mHolderKey = 0;

        public KindOfValue Kind => KindOfValue.Logical;

        private ulong mTypeKey = 0;

        public ulong TypeKey => mTypeKey;

        public bool IsProperty => true;
        public bool IsVariable => false;
        public bool IsValueContainer => true;
        public IValue ValueFromContainer
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        public bool IsNull => false;
        public bool IsUndefined => false;
        public bool IsNullOrUndefined => false;

        public ResultOfCalling ExecuteSetLogicalProperty(IValue value, KindOfLogicalOperator kindOfLogicalOperators)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteSetLogicalProperty IS NOT IMPLEMENTED YET value = {value} kindOfLogicalOperators = {kindOfLogicalOperators}");
            var result = new ResultOfCalling();
            result.Success = true;
            result.Result = new EntityValue(1);
            return result;
#endif
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
            return $"LogicalPropertyValue {nameof(TypeKey)} = {TypeKey}; {nameof(Kind)}= {Kind}; HolderKey = {mHolderKey}";
        }
    }
}
