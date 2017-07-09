using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewFunctionsEngine
    {
        public NewFunctionsEngine(GnuClayEngineComponentContext context)
        {
            mContext = context;
            mAdditionalContext = new NewAdditionalGnuClayEngineComponentContext();
            mAdditionalContext.NewFunctionEngine = this;
            mCommandFiltersStorage = new NewCommandFiltersStorage<NewCommandFilter>(mContext, mAdditionalContext);

            mSelfKey = mContext.DataDictionary.GetKey(mSelfName);

            mSelfValue = new NewEntityValue(mSelfKey);
        }

        private GnuClayEngineComponentContext mContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;
        private NewCommandFiltersStorage<NewCommandFilter> mCommandFiltersStorage = null;

        private string mSelfName = "self";
        private ulong mSelfKey = 0;

        private INewValue mSelfValue = null;

        public void CallCodeFrame(FunctionModel source)
        {
            var context = new NewGnuClayThreadExecutionContext();
            context.ContextOfVariables = new NewContextOfVariables();

            var tmpNewInternalThreadExecutor = new NewInternalFunctionExecutionModel(source, mContext, mAdditionalContext, context);
            tmpNewInternalThreadExecutor.Run();
        }

        public NewResultOfCalling CallByNamedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters command = {command}");

            var entityAction = CreateEntityAction(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters entityAction = {entityAction}");

            throw new NotImplementedException();

            var result = new NewResultOfCalling();
            result.Success = true;//tmp
            result.Result = new NewEntityValue(15);//tmp

            NLog.LogManager.GetCurrentClassLogger().Info("End CallByNamedParameters");

            return result;
        }

        public NewResultOfCalling CallByPositionedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters command = {command}");

            var entityAction = CreateEntityAction(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters entityAction = {entityAction}");

            throw new NotImplementedException();

            var result = new NewResultOfCalling();
            result.Success = true;//tmp
            result.Result = new NewEntityValue(15);//tmp

            NLog.LogManager.GetCurrentClassLogger().Info("End CallByPositionedParameters");

            return result;
        }

        public NewResultOfCalling CallAsyncByNamedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters command = {command}");

            var entityAction = CreateEntityAction(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters entityAction = {entityAction}");

            var result = new NewResultOfCalling();


            NLog.LogManager.GetCurrentClassLogger().Info("End CallAsyncByNamedParameters");

            return result;
        }

        public NewResultOfCalling CallAsyncByPositionedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters command = {command}");

            var entityAction = CreateEntityAction(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters entityAction = {entityAction}");

            var result = new NewResultOfCalling();

            NLog.LogManager.GetCurrentClassLogger().Info("End CallAsyncByPositionedParameters");

            return result;
        }

        private NewCommand CreateCommandByNamedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewNamedParamInfo> namedParams)
        {
            var command = new NewCommand();
            command.ExecutionContext = executionContext;
            command.Function = function;

            if(holder == null)
            {
                holder = mSelfValue;
            }

            command.Holder = holder;
            command.TargetKey = targetKey;

            command.IsCallByNamedParams = true;

            command.NamedParams = namedParams;

            return command;
        }

        private NewCommand CreateCommandByPositionedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            var command = new NewCommand();
            command.ExecutionContext = executionContext;
            command.Function = function;

            if (holder == null)
            {
                holder = mSelfValue;
            }

            command.Holder = holder;
            command.TargetKey = targetKey;

            command.IsCallByNamedParams = false;

            command.PositionedParams = positionedParams;

            return command;
        }

        private NewEntityAction CreateEntityAction(NewCommand command)
        {
            var name = Guid.NewGuid().ToString("D");
            var key = mContext.DataDictionary.GetKey(name);
            var entityAction = new NewEntityAction(name, key, command);

            return entityAction;
        }

        private object mFiltersLockObj = new object();

        public void AddFilter(NewCommandFilter filter)
        {
            lock(mFiltersLockObj)
            {
                mCommandFiltersStorage.AddFilter(filter);
            }
        }
    }
}
