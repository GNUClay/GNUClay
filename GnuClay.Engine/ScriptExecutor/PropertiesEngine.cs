using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class PropertiesEngine : BaseGnuClayEngineComponent
    {
        public PropertiesEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mPropertiesFiltersStorage = new PropertiesFiltersStorage(context);
        }

        private object mLockObj = new object();

        private PropertiesFiltersStorage mPropertiesFiltersStorage = null;

        public ulong AddFilter(PropertyFilter filter)
        {
            lock(mLockObj)
            {
                return mPropertiesFiltersStorage.AddFilter(filter);
            }
        }

        public ResultOfCalling CallProperty(IValue holder, ulong propertyKey, IValue value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallProperty holder = {holder} propertyKey = {propertyKey} value = {value}");

            if(holder.Kind == KindOfValue.Logical)
            {
                return CallLogicalHolder(holder, propertyKey, value);
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"CallProperty NEXT holder = {holder} propertyKey = {propertyKey} value = {value}");

            throw new NotImplementedException();
        }

        private ResultOfCalling CallLogicalHolder(IValue holder, ulong propertyKey, IValue value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallLogicalHolder holder = {holder} propertyKey = {propertyKey} value = {value}");

            throw new NotImplementedException();
        }
    }
}
