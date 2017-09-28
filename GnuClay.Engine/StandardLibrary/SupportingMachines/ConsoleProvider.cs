using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Console;
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
        private ConsoleEngine mConsoleEngine = null;

        public override void FirstInit()
        {
            mDataDictionary = Context.DataDictionary;
            mCommonKeysEngine = Context.CommonKeysEngine;
            mFunctionsEngine = Context.FunctionsEngine;
            mConsoleEngine = Context.ConsoleEngine;
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
            var command = action.Command;
            var tmpMessageParam = command.GetParamValue(MessageParamKey);
            mConsoleEngine.Emit(tmpMessageParam);
            action.State = EntityActionState.Completed;
        }
    }
}
