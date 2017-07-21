using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CommonUtils.TypeHelpers;

namespace GnuClay.Engine.ScriptExecutor
{
    public class FunctionsEngine : BaseGnuClayEngineComponent
    {
        public FunctionsEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        private string mSelfName = "self";
        private ulong mSelfKey = 0;

        private IValue mSelfValue = null;

        private string mEntityActionTypeName = "EntityAction";
        private ulong mEntityActionTypeKey = 0;

        private ulong mUndefinedTypeKey = 0;
        private CommandFiltersStorage<CommandFilter> mCommandFiltersStorage = null;

        public override void FirstInit()
        {
            mCommandFiltersStorage = new CommandFiltersStorage<CommandFilter>(Context);

            var universalTypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            mSelfKey = Context.DataDictionary.GetKey(mSelfName);

            Context.InheritanceEngine.SetInheritance(mSelfKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);

            mSelfValue = new EntityValue(mSelfKey);

            mEntityActionTypeKey = Context.DataDictionary.GetKey(mEntityActionTypeName);

            Context.InheritanceEngine.SetInheritance(mEntityActionTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);

            mUndefinedTypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.UndefinedTypeMame);
        }

        public ResultOfCalling CallCodeFrame(FunctionModel source)
        {
            var executionContext = CreateEmptyExecutionContext();

            var entityAction = CreateEntityAction(new Command(), null);

            var tmpNewInternalThreadExecutor = new InternalFunctionExecutionModel(source, Context, executionContext, entityAction);
            tmpNewInternalThreadExecutor.RunDbg();

            return CreateSyncResultOfCalling(entityAction);
        }

        public void CallCodeFrameForEntityAction(FunctionModel source, CommandFilter filter, EntityAction entityAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallCodeFrameForEntityAction source = {source}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallCodeFrameForEntityAction entityAction = {entityAction}");
            NLog.LogManager.GetCurrentClassLogger().Info($"CallCodeFrameForEntityAction filter = {filter}");

            var executionContext = CreateEmptyExecutionContext();

            FillVariablesByParams(filter, entityAction, executionContext);

            var tmpNewInternalThreadExecutor = new InternalFunctionExecutionModel(source, Context, executionContext, entityAction);
            tmpNewInternalThreadExecutor.RunDbg();

            NLog.LogManager.GetCurrentClassLogger().Info($"End CallCodeFrameForEntityAction entityAction = {entityAction}");
        }

        private void FillVariablesByParams(CommandFilter filter, EntityAction entityAction, GnuClayThreadExecutionContext executionContext)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByParams entityAction = {entityAction}");
            NLog.LogManager.GetCurrentClassLogger().Info($"FillVariablesByParams filter = {filter}");

            if (filter.Params.Count == 0)
            {
                return;
            }

            if (entityAction.Command.IsCallByNamedParams)
            {
                FillVariablesByNamedParams(filter, entityAction, executionContext);
                return;
            }

            FillVariablesByPositionedParams(filter, entityAction, executionContext);
        }

        private void FillVariablesByNamedParams(CommandFilter filter, EntityAction entityAction, GnuClayThreadExecutionContext executionContext)
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

        private void FillVariablesByPositionedParams(CommandFilter filter, EntityAction entityAction, GnuClayThreadExecutionContext executionContext)
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

        public ResultOfCalling CallByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
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

        public ResultOfCalling CallByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
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

        public ResultOfCalling CallAsyncByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
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

        public ResultOfCalling CallAsyncByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
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

        private GnuClayThreadExecutionContext CreateEmptyExecutionContext()
        {
            var executionContext = new GnuClayThreadExecutionContext();
            executionContext.ContextOfVariables = new ContextOfVariables();
            return executionContext;
        }

        private Command CreateCommandByNamedParameters(GnuClayThreadExecutionContext executionContext, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var command = new Command();
            command.ExecutionContext = executionContext;
            command.Function = function;

            if (holder == null)
            {
                holder = mSelfValue;
            }

            command.Holder = holder;
            command.TargetKey = targetKey;
            command.IsCallByNamedParams = true;
            command.NamedParams = namedParams;

            return command;
        }

        private Command CreateCommandByPositionedParameters(GnuClayThreadExecutionContext executionContext, IValue function, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var command = new Command();
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

        private EntityAction CreateEntityAction(Command command, EntityAction parentAction)
        {
            var name = Guid.NewGuid().ToString("D");
            var key = Context.DataDictionary.GetKey(name);
            var entityAction = new EntityAction(name, key, command, mEntityActionTypeKey);

            if (parentAction != null)
            {
                entityAction.Initiator = parentAction.Key;
                parentAction.InitiatedActions.Add(key);
            }

            return entityAction;
        }

        private void InvokeEntityAction(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction action = {action}");

            var targetExecutorsList = FindExecutors(action.Command);

            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction targetExecutorsList.Count = {targetExecutorsList.Count}");

            if (_ListHelper.IsEmpty(targetExecutorsList))
            {
                action.Error = Context.ErrorsFactory.CreateUncaughtReferenceError();
                action.State = EntityActionState.Faulted;

                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"InvokeEntityAction NEXT action = {action}");

            var targetAction = targetExecutorsList.FirstOrDefault();

            targetAction.Handler.Invoke(action);
        }

        private ResultOfCalling ProcessSyncCall(Command command, EntityAction parentAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSyncCall command = {command}");

            var entityAction = CreateEntityAction(command, parentAction);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessSyncCall entityAction = {entityAction}");

            InvokeEntityAction(entityAction);

            return CreateSyncResultOfCalling(entityAction);
        }

        private ResultOfCalling CreateSyncResultOfCalling(EntityAction entityAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CreateSyncResultOfCalling entityAction = {entityAction}");

            var result = new ResultOfCalling();

            if (entityAction.State == EntityActionState.Completed)
            {
                result.Success = true;

                if (entityAction.Result == null)
                {
                    entityAction.Result = new EntityValue(mUndefinedTypeKey);
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

        private ResultOfCalling ProcessAsyncCall(Command command, EntityAction parentAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAsyncCall command = {command}");

            var entityAction = CreateEntityAction(command, parentAction);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAsyncCall entityAction = {entityAction}");

            Task.Run(() => {
                InvokeEntityAction(entityAction);
            });

            var result = new ResultOfCalling();
            result.Success = true;
            result.Result = entityAction;

            NLog.LogManager.GetCurrentClassLogger().Info($"End ProcessAsyncCall result = {result}");

            return result;
        }

        private object mFiltersLockObj = new object();

        public ulong AddFilter(CommandFilter filter)
        {
            lock (mFiltersLockObj)
            {
                return mCommandFiltersStorage.AddFilter(filter);
            }
        }

        private List<CommandFilter> FindExecutors(Command command)
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
