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
using GnuClay.Engine.CommonStorages;

namespace GnuClay.Engine.ScriptExecutor
{
    public class FunctionsEngine : BaseGnuClayEngineComponent
    {
        public FunctionsEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private CommonValuesFactory mCommonValuesFactory = null;
        private CommonKeysEngine mCommonKeysEngine = null;
        private StorageDataDictionary mDataDictionary = null;

        private ulong mEntityActionTypeKey = 0;

        private CommandFiltersStorage<CommandFilter> mCommandFiltersStorage = null;

        public override void FirstInit()
        {
            mCommonValuesFactory = Context.CommonValuesFactory;
            mCommonKeysEngine = Context.CommonKeysEngine;
            mDataDictionary = Context.DataDictionary;

            mCommandFiltersStorage = new CommandFiltersStorage<CommandFilter>(Context);
        }

        public override void SecondInit()
        {
            mEntityActionTypeKey = mCommonKeysEngine.EntityActionTypeKey;
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
            var executionContext = CreateEmptyExecutionContext();

            FillVariablesByParams(filter, entityAction, executionContext);

            var tmpNewInternalThreadExecutor = new InternalFunctionExecutionModel(source, Context, executionContext, entityAction);
            tmpNewInternalThreadExecutor.RunDbg();
        }

        private void FillVariablesByParams(CommandFilter filter, EntityAction entityAction, GnuClayThreadExecutionContext executionContext)
        {
            if (filter.Params.Count == 0)
            {
                return;
            }

            var tmpFilterParameters = filter.Params;
            var tmpCommandParamsDict = entityAction.Command.NamedParams.ToDictionary(p => p.ParamName.TypeKey, p => p);

            foreach (var filterParamKVP in tmpFilterParameters)
            {
                var paramKey = filterParamKVP.Key;

                if (tmpCommandParamsDict.ContainsKey(paramKey))
                {
                    var targetParamOfCommand = tmpCommandParamsDict[paramKey];
                    executionContext.ContextOfVariables.CreateVariable(paramKey, targetParamOfCommand.ParamValue);
                    continue;
                }

                throw new NotImplementedException();
            }
        }

        public ResultOfCalling CallByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var executionContext = CreateEmptyExecutionContext();
            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);
            return ProcessSyncCall(command, parentAction);
        }

        public ResultOfCalling CallByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var executionContext = CreateEmptyExecutionContext();
            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);
            return ProcessSyncCall(command, parentAction);
        }

        public ResultOfCalling CallAsyncByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var executionContext = CreateEmptyExecutionContext();
            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);
            return ProcessAsyncCall(command, parentAction);
        }

        public ResultOfCalling CallAsyncByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var executionContext = CreateEmptyExecutionContext();
            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);
            return ProcessAsyncCall(command, parentAction);
        }

        public ResultOfCalling CallForDecsriptorByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, IValue holder, ulong descriptor, ulong targetKey, List<NamedParamInfo> namedParams)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"CallForDecsriptorByNamedParameters holder = {holder} descriptor = {descriptor} targetKey = {targetKey} namedParams = {_ListHelper._ToString(namedParams)}");
#endif

            var executionContext = CreateEmptyExecutionContext();

            throw new NotImplementedException();
        }

        public ResultOfCalling CallForDecsriptorByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, IValue holder, ulong descriptor, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"CallForDecsriptorByPositionedParameters holder = {holder} descriptor = {descriptor} targetKey = {targetKey} positionedParams = {_ListHelper._ToString(positionedParams)}");
#endif

            var executionContext = CreateEmptyExecutionContext();

            throw new NotImplementedException();
        }

        public ResultOfCalling CallAsyncForDecsriptorByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, IValue holder, ulong descriptor, ulong targetKey, List<NamedParamInfo> namedParams)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncForDecsriptorByNamedParameters holder = {holder} descriptor = {descriptor} targetKey = {targetKey} namedParams = {_ListHelper._ToString(namedParams)}");
#endif

            var executionContext = CreateEmptyExecutionContext();

            throw new NotImplementedException();
        }

        public ResultOfCalling CallAsyncForDecsriptorByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, IValue holder, ulong descriptor, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"CallAsyncForDecsriptorByPositionedParameters holder = {holder} descriptor = {descriptor} targetKey = {targetKey} positionedParams = {_ListHelper._ToString(positionedParams)}");
#endif

            var executionContext = CreateEmptyExecutionContext();

            throw new NotImplementedException();
        }

        private GnuClayThreadExecutionContext CreateEmptyExecutionContext()
        {
            var executionContext = new GnuClayThreadExecutionContext();
            executionContext.ContextOfVariables = new ContextOfVariables(Context);
            return executionContext;
        }

        private Command CreateCommandByNamedParameters(GnuClayThreadExecutionContext executionContext, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var command = new Command();
            command.ExecutionContext = executionContext;
            command.Function = function;

            if (holder == null)
            {
                holder = mCommonValuesFactory.SelfValue();
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
                holder = mCommonValuesFactory.SelfValue();
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
            var entityAction = new EntityAction(key, command, mEntityActionTypeKey);

            if (parentAction != null)
            {
                entityAction.Initiator = parentAction.Key;
                parentAction.InitiatedActions.Add(key);
            }

            return entityAction;
        }

        private void InvokeEntityAction(EntityAction action)
        {
            var command = action.Command;

            var commandHashCode = command.GetLongHashCode();

            if(mCommandErrorsCacheDict.ContainsKey(commandHashCode))
            {
                action.State = EntityActionState.Faulted;
                action.Error = mCommandErrorsCacheDict[commandHashCode];
                return;
            }

            CommandFilter targetExecutor = null;

            if (mCommandFiltersCacheDict.ContainsKey(commandHashCode))
            {
                targetExecutor = mCommandFiltersCacheDict[commandHashCode];

                if(command.Function.TypeKey == targetExecutor.FunctionKey)
                {
                    NormalizeCommandParams(command, targetExecutor);

                    targetExecutor.Handler.Invoke(action);

                    return;
                }
            }

            var targetExecutorsList = FindExecutors(command);

            if (_ListHelper.IsEmpty(targetExecutorsList))
            {
                action.Error = Context.ErrorsFactory.CreateUncaughtReferenceError();
                action.State = EntityActionState.Faulted;

                return;
            }

            targetExecutor = targetExecutorsList.FirstOrDefault();

            NormalizeCommandParams(command, targetExecutor);

            targetExecutor.Handler.Invoke(action);

            if(action.State == EntityActionState.Faulted)
            {
                mCommandErrorsCacheDict[commandHashCode] = action.Error;
                return;
            }

            if(targetExecutor.WithOutClause)
            {
                mCommandFiltersCacheDict[commandHashCode] = targetExecutor;
            }
        }

        /// <summary>
        /// Translate positioned params to named params.
        /// </summary>
        /// <param name="command">Target command.</param>
        /// <param name="targetExecutor">Evecutor for this command.</param>
        private void NormalizeCommandParams(Command command, CommandFilter targetExecutor)
        {
            if(command.IsCallByNamedParams)
            {
                command.CreateParamsDict();
                return;
            }

            var tmpFilterParameters = targetExecutor.Params;
            var tmpCommandListEnumerator = command.PositionedParams.GetEnumerator();

            var tmpNamedParams = new List<NamedParamInfo>();
            command.NamedParams = tmpNamedParams;

            foreach (var filterParamKVP in tmpFilterParameters)
            {
                var paramKey = filterParamKVP.Key;

                if (tmpCommandListEnumerator.MoveNext())
                {
                    var targetParamOfCommand = tmpCommandListEnumerator.Current;

                    var item = new NamedParamInfo();
                    item.ParamName = new EntityValue(paramKey);
                    item.ParamValue = targetParamOfCommand.ParamValue;
                    command.NamedParams.Add(item);
                    continue;
                }

                throw new NotImplementedException();
            }

            command.IsCallByNamedParams = true;
            command.PositionedParams = null;
            command.CreateParamsDict();
        }

        private ResultOfCalling ProcessSyncCall(Command command, EntityAction parentAction)
        {
            var entityAction = CreateEntityAction(command, parentAction);

            InvokeEntityAction(entityAction);

            return CreateSyncResultOfCalling(entityAction);
        }

        private ResultOfCalling CreateSyncResultOfCalling(EntityAction entityAction)
        {
            var result = new ResultOfCalling();

            if (entityAction.State == EntityActionState.Completed)
            {
                result.Success = true;

                if (entityAction.Result == null)
                {
                    entityAction.Result = mCommonValuesFactory.UndefinedValue();
                }

                result.Result = entityAction.Result;
            }
            else
            {
                result.Success = false;
                result.Error = entityAction.Error;
            }

            return result;
        }

        private ResultOfCalling ProcessAsyncCall(Command command, EntityAction parentAction)
        {
            var entityAction = CreateEntityAction(command, parentAction);

            //TODO: fix at #16 Organize stopping and resuming script execution 
            Task.Run(() => {
                InvokeEntityAction(entityAction);
            });

            var result = new ResultOfCalling();
            result.Success = true;
            result.Result = entityAction;

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
            lock (mFiltersLockObj)
            {
                mCommandFiltersStorage.RemoveFilter(descriptor);
            }
        }

        private Dictionary<ulong, CommandFilter> mCommandFiltersCacheDict = new Dictionary<ulong, CommandFilter>();
        private Dictionary<ulong, IValue> mCommandErrorsCacheDict = new Dictionary<ulong, IValue>();

        private void InvalidateCache()
        {
            mCommandFiltersCacheDict.Clear();
            mCommandErrorsCacheDict.Clear();
        }
    }
}
