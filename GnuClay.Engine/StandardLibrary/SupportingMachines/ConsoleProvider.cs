using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalBus;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class ConsoleProvider : BaseGnuClayEngineComponent
    {
        public ConsoleProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private StorageDataDictionary mDataDictionary = null;
        private CommonKeysEngine mCommonKeysEngine = null;
        private FunctionsEngine mFunctionsEngine = null;

        public override void FirstInit()
        {
            mDataDictionary = Context.DataDictionary;
            mCommonKeysEngine = Context.CommonKeysEngine;
            mFunctionsEngine = Context.FunctionsEngine;
        }

        private ulong SelfInstanceKey = 0;
        private ulong ConsoleKey = 0;
        private ulong LogKey = 0;
        private ulong MessageParamKey = 0;

        public override void SecondInit()
        {
            SelfInstanceKey = mCommonKeysEngine.SelfInstanceKey;
            ConsoleKey = mDataDictionary.GetKey("console");
            LogKey = mDataDictionary.GetKey("log");
            MessageParamKey = mCommonKeysEngine.MessageParamKey;

            RegHandlerOfLog();
        }

        private void RegHandlerOfLog()
        {
            var filter = new CommandFilter();
            filter.Handler = Log;
            filter.HolderKey = ConsoleKey;
            filter.FunctionKey = LogKey;

            filter.Params.Add(MessageParamKey, new CommandFilterParam()
            {
            });

            mFunctionsEngine.AddFilter(filter);
        }

        private void Log(EntityAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin Log action = {action}");
#endif
            var command = action.Command;

            var tmpMessageParam = command.GetParamValue(MessageParamKey);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Log tmpMessageParam = {tmpMessageParam.ToString(mDataDictionary, 0)}");
#endif


            action.State = EntityActionState.Completed;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"End Log action = {action}");
#endif
        }
    }
}
