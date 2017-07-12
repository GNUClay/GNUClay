using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewFunctionsEngine
    {
        public NewFunctionsEngine(GnuClayEngineComponentContext context, NewAdditionalGnuClayEngineComponentContext additionalContext)
        {
            mContext = context;
            mAdditionalContext = additionalContext;

            mCommandFiltersStorage = new NewCommandFiltersStorage<NewCommandFilter>(mContext, mAdditionalContext);

            var universalTypeKey = mContext.DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            mSelfKey = mContext.DataDictionary.GetKey(mSelfName);

            mContext.InheritanceEngine.SetInheritance(mSelfKey, universalTypeKey, 1 , InheritanceAspect.WithOutClause);

            mSelfValue = new NewEntityValue(mSelfKey);

            mEntityActionTypeKey = mContext.DataDictionary.GetKey(mEntityActionTypeName);

            mContext.InheritanceEngine.SetInheritance(mEntityActionTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);
        }

        private GnuClayEngineComponentContext mContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;
        private NewCommandFiltersStorage<NewCommandFilter> mCommandFiltersStorage = null;

        private string mSelfName = "self";
        private ulong mSelfKey = 0;

        private INewValue mSelfValue = null;

        private string mEntityActionTypeName = "EntityAction";
        private ulong mEntityActionTypeKey = 0;

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

            return ProcessSyncCall(command);
        }

        public NewResultOfCalling CallByPositionedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters command = {command}");

            return ProcessSyncCall(command);
        }

        public NewResultOfCalling CallAsyncByNamedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters command = {command}");

            return ProcessAsyncCall(command);
        }

        public NewResultOfCalling CallAsyncByPositionedParameters(NewGnuClayThreadExecutionContext executionContext, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters command = {command}");

            return ProcessAsyncCall(command);
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
            var entityAction = new NewEntityAction(name, key, command, mEntityActionTypeKey);

            return entityAction;
        }

        private void InvokeEntityAction(NewEntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction action = {action}");

            var targetExecutorsList = FindExecutors(action.Command);

            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction targetExecutorsList.Count = {targetExecutorsList.Count}");

            if(_ListHelper.IsEmpty(targetExecutorsList))
            {
                throw new NotImplementedException();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction NEXT action = {action}");

            var targetAction = targetExecutorsList.FirstOrDefault();

            targetAction.Handler.Invoke(action);
        }

        private NewResultOfCalling ProcessSyncCall(NewCommand command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSyncCall command = {command}");

            var entityAction = CreateEntityAction(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSyncCall entityAction = {entityAction}");

            InvokeEntityAction(entityAction);

            var result = new NewResultOfCalling();

            if (entityAction.State == NewEntityActionState.Completed)
            {
                result.Success = true;

                if (entityAction.Result == null)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    result.Result = entityAction.Result;
                }
            }
            else
            {
                result.Success = false;
                throw new NotImplementedException();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End ProcessSyncCall result = {result}");

            return result;
        }

        private NewResultOfCalling ProcessAsyncCall(NewCommand command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAsyncCall command = {command}");

            var entityAction = CreateEntityAction(command);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAsyncCall entityAction = {entityAction}");

            InvokeEntityAction(entityAction);

            var result = new NewResultOfCalling();
            result.Success = true;
            result.Result = entityAction;

            NLog.LogManager.GetCurrentClassLogger().Info($"End ProcessAsyncCall result = {result}");

            return result;
        }

        private object mFiltersLockObj = new object();

        public void AddFilter(NewCommandFilter filter)
        {
            lock(mFiltersLockObj)
            {
                mCommandFiltersStorage.AddFilter(filter);
            }
        }

        private List<NewCommandFilter> FindExecutors(NewCommand command)
        {
            lock (mFiltersLockObj)
            {
                return mCommandFiltersStorage.FindExecutors(command);
            }
        }
    }
}
