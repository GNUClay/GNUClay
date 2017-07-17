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

            mUndefinedTypeKey = mContext.DataDictionary.GetKey(StandartTypeNamesConstants.UndefinedTypeMame);
        }

        private GnuClayEngineComponentContext mContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;
        private NewCommandFiltersStorage<NewCommandFilter> mCommandFiltersStorage = null;

        private string mSelfName = "self";
        private ulong mSelfKey = 0;

        private INewValue mSelfValue = null;

        private string mEntityActionTypeName = "EntityAction";
        private ulong mEntityActionTypeKey = 0;

        private ulong mUndefinedTypeKey = 0;

        public NewResultOfCalling CallCodeFrame(FunctionModel source)
        {
            var executionContext = CreateEmptyExecutionContext();

            var entityAction = CreateEntityAction(new NewCommand(), null);

            var tmpNewInternalThreadExecutor = new NewInternalFunctionExecutionModel(source, mContext, mAdditionalContext, executionContext, entityAction);
            tmpNewInternalThreadExecutor.Run();

            return CreateSyncResultOfCalling(entityAction);
        }

        public void CallCodeFrameForEntityAction(FunctionModel source, NewCommandFilter filter, NewEntityAction entityAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallCodeFrameForEntityAction source = {source}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallCodeFrameForEntityAction entityAction = {entityAction}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallCodeFrameForEntityAction filter = {filter}");

            var executionContext = CreateEmptyExecutionContext();

            FillVariablesByParams(filter, entityAction, executionContext);

            var tmpNewInternalThreadExecutor = new NewInternalFunctionExecutionModel(source, mContext, mAdditionalContext, executionContext, entityAction);
            tmpNewInternalThreadExecutor.Run();

            NLog.LogManager.GetCurrentClassLogger().Info($"End CallCodeFrameForEntityAction entityAction = {entityAction}");
        }

        private void FillVariablesByParams(NewCommandFilter filter, NewEntityAction entityAction, NewGnuClayThreadExecutionContext executionContext)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByParams entityAction = {entityAction}");
            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByParams filter = {filter}");

            if(filter.Params.Count == 0)
            {
                return;
            }

            if(entityAction.Command.IsCallByNamedParams)
            {
                FillVariablesByNamedParams(filter, entityAction, executionContext);
                return;
            }

            FillVariablesByPositionedParams(filter, entityAction, executionContext);
        }

        private void FillVariablesByNamedParams(NewCommandFilter filter, NewEntityAction entityAction, NewGnuClayThreadExecutionContext executionContext)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams entityAction = {entityAction}");
            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams filter = {filter}");

            var tmpFilterParameters = filter.Params;

            var tmpCommandParamsDict = entityAction.Command.NamedParams.ToDictionary(p => p.ParamName.TypeKey, p => p);

            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams before executionContext.ContextOfVariables = {executionContext.ContextOfVariables.ToDbgString()}");

            foreach (var filterParamKVP in tmpFilterParameters)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams filterParamKVP = {filterParamKVP}");

                var paramKey = filterParamKVP.Key;

                if (tmpCommandParamsDict.ContainsKey(paramKey))
                {
                    var targetParamOfCommand = tmpCommandParamsDict[paramKey];

                    NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams targetParamOfCommand = {targetParamOfCommand}");

                    executionContext.ContextOfVariables.SetValue(paramKey, targetParamOfCommand.ParamValue);

                    continue;
                }

                throw new NotImplementedException();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams after executionContext.ContextOfVariables = {executionContext.ContextOfVariables.ToDbgString()}");
        }

        private void FillVariablesByPositionedParams(NewCommandFilter filter, NewEntityAction entityAction, NewGnuClayThreadExecutionContext executionContext)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByPositionedParams entityAction = {entityAction}");
            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByPositionedParams filter = {filter}");

            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams before executionContext.ContextOfVariables = {executionContext.ContextOfVariables.ToDbgString()}");

            var tmpFilterParameters = filter.Params;
            var tmpCommandListEnumerator = entityAction.Command.PositionedParams.GetEnumerator();

            foreach (var filterParamKVP in tmpFilterParameters)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByPositionedParam filterParamKVP = {filterParamKVP}");

                var paramKey = filterParamKVP.Key;

                if (tmpCommandListEnumerator.MoveNext())
                {
                    var targetParamOfCommand = tmpCommandListEnumerator.Current;

                    NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams targetParamOfCommand = {targetParamOfCommand}");

                    executionContext.ContextOfVariables.SetValue(paramKey, targetParamOfCommand.ParamValue);

                    continue;
                }

                throw new NotImplementedException();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByNamedParams after executionContext.ContextOfVariables = {executionContext.ContextOfVariables.ToDbgString()}");
        }

        public NewResultOfCalling CallByNamedParameters(NewGnuClayThreadExecutionContext parentExecutionContext, NewEntityAction parentAction, INewValue function, INewValue holder, ulong targetKey, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var executionContext = CreateEmptyExecutionContext();

            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByNamedParameters command = {command}");

            return ProcessSyncCall(command, parentAction);
        }

        public NewResultOfCalling CallByPositionedParameters(NewGnuClayThreadExecutionContext parentExecutionContext, NewEntityAction parentAction, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var executionContext = CreateEmptyExecutionContext();

            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallByPositionedParameters command = {command}");

            return ProcessSyncCall(command, parentAction);
        }

        public NewResultOfCalling CallAsyncByNamedParameters(NewGnuClayThreadExecutionContext parentExecutionContext, NewEntityAction parentAction, INewValue function, INewValue holder, ulong targetKey, List<NewNamedParamInfo> namedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters namedParams = {_ListHelper._ToString(namedParams)}");

            var executionContext = CreateEmptyExecutionContext();

            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByNamedParameters command = {command}");

            return ProcessAsyncCall(command, parentAction);
        }

        public NewResultOfCalling CallAsyncByPositionedParameters(NewGnuClayThreadExecutionContext parentExecutionContext, NewEntityAction parentAction, INewValue function, INewValue holder, ulong targetKey, List<NewPositionParamInfo> positionedParams)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters function = {function}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters holder = {holder}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters targetKey = {targetKey}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters positionedParams = {_ListHelper._ToString(positionedParams)}");

            var executionContext = CreateEmptyExecutionContext();

            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncByPositionedParameters command = {command}");

            return ProcessAsyncCall(command, parentAction);
        }

        private NewGnuClayThreadExecutionContext CreateEmptyExecutionContext()
        {
            var executionContext = new NewGnuClayThreadExecutionContext();
            executionContext.ContextOfVariables = new NewContextOfVariables();
            return executionContext;
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

        private NewEntityAction CreateEntityAction(NewCommand command, NewEntityAction parentAction)
        {
            var name = Guid.NewGuid().ToString("D");
            var key = mContext.DataDictionary.GetKey(name);
            var entityAction = new NewEntityAction(name, key, command, mEntityActionTypeKey);

            if(parentAction != null)
            {
                entityAction.Initiator = parentAction.Key;
                parentAction.InitiatedActions.Add(key);
            }

            return entityAction;
        }

        private void InvokeEntityAction(NewEntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction action = {action}");

            var targetExecutorsList = FindExecutors(action.Command);

            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction targetExecutorsList.Count = {targetExecutorsList.Count}");

            if(_ListHelper.IsEmpty(targetExecutorsList))
            {
                action.Error = mAdditionalContext.ErrorsFactory.CreateUncaughtReferenceError();
                action.State = NewEntityActionState.Faulted;

                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction NEXT action = {action}");

            var targetAction = targetExecutorsList.FirstOrDefault();

            targetAction.Handler.Invoke(action);
        }

        private NewResultOfCalling ProcessSyncCall(NewCommand command, NewEntityAction parentAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSyncCall command = {command}");

            var entityAction = CreateEntityAction(command, parentAction);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSyncCall entityAction = {entityAction}");

            InvokeEntityAction(entityAction);

            return CreateSyncResultOfCalling(entityAction);
        }

        private NewResultOfCalling CreateSyncResultOfCalling(NewEntityAction entityAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CreateSyncResultOfCalling entityAction = {entityAction}");

            var result = new NewResultOfCalling();

            if (entityAction.State == NewEntityActionState.Completed)
            {
                result.Success = true;

                if (entityAction.Result == null)
                {
                    entityAction.Result = new NewEntityValue(mUndefinedTypeKey);
                }

                result.Result = entityAction.Result;
            }
            else
            {
                result.Success = false;
                result.Error = entityAction.Error;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End CreateSyncResultOfCalling result = {result}");

            return result;
        }

        private NewResultOfCalling ProcessAsyncCall(NewCommand command, NewEntityAction parentAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAsyncCall command = {command}");

            var entityAction = CreateEntityAction(command, parentAction);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAsyncCall entityAction = {entityAction}");

            InvokeEntityAction(entityAction);

            var result = new NewResultOfCalling();
            result.Success = true;
            result.Result = entityAction;

            NLog.LogManager.GetCurrentClassLogger().Info($"End ProcessAsyncCall result = {result}");

            return result;
        }

        private object mFiltersLockObj = new object();

        public ulong AddFilter(NewCommandFilter filter)
        {
            lock(mFiltersLockObj)
            {
                return mCommandFiltersStorage.AddFilter(filter);
            }
        }

        private List<NewCommandFilter> FindExecutors(NewCommand command)
        {
            lock (mFiltersLockObj)
            {
                return mCommandFiltersStorage.FindExecutors(command);
            }
        }

        public void RemoveFilter(ulong descriptor)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFilter descriptor = {descriptor}");

            lock (mFiltersLockObj)
            {
                mCommandFiltersStorage.RemoveFilter(descriptor);
            }
        }
    }
}
