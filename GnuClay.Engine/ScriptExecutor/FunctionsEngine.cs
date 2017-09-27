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
        private ScriptExecutorEngine mScriptExecutorEngine = null;

        private ulong mEntityActionTypeKey = 0;

        private CommandFiltersStorage<CommandFilter> mCommandFiltersStorage = null;

        public override void FirstInit()
        {
            mCommonValuesFactory = Context.CommonValuesFactory;
            mCommonKeysEngine = Context.CommonKeysEngine;
            mDataDictionary = Context.DataDictionary;
            mScriptExecutorEngine = Context.ScriptExecutor;

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

            var tmpNewInternalThreadExecutor = new InternalThreadExecutor(source, Context, executionContext, entityAction);
            ExecuteThread(tmpNewInternalThreadExecutor);

            return CreateSyncResultOfCalling(entityAction);
        }

        public ResultOfCalling CallByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var executionContext = CreateExecutionContext(parentExecutionContext);
            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);
            return ProcessSyncCall(command, parentAction);
        }

        public ResultOfCalling CallByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var executionContext = CreateExecutionContext(parentExecutionContext);
            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);
            return ProcessSyncCall(command, parentAction);
        }

        public ResultOfCalling CallAsyncByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var executionContext = CreateExecutionContext(parentExecutionContext);
            var command = CreateCommandByNamedParameters(executionContext, function, holder, targetKey, namedParams);
            return ProcessAsyncCall(command, parentAction);
        }

        public ResultOfCalling CallAsyncByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue function, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var executionContext = CreateExecutionContext(parentExecutionContext);
            var command = CreateCommandByPositionedParameters(executionContext, function, holder, targetKey, positionedParams);
            return ProcessAsyncCall(command, parentAction);
        }

        public ResultOfCalling CallForDecsriptorByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue holder, ulong descriptor, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var executionContext = CreateExecutionContext(parentExecutionContext);
            var command = CreateCommandForDescriptorByNamedParameters(executionContext, descriptor, holder, targetKey, namedParams);
            return ProcessSyncCallForDescriptor(command, parentAction);
        }

        public ResultOfCalling CallForDecsriptorByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue holder, ulong descriptor, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var executionContext = CreateExecutionContext(parentExecutionContext);
            var command = CreateCommandForDescriptorByPositionedParameters(executionContext, descriptor, holder, targetKey, positionedParams);
            return ProcessSyncCallForDescriptor(command, parentAction);
        }

        public ResultOfCalling CallAsyncForDecsriptorByNamedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue holder, ulong descriptor, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var executionContext = CreateExecutionContext(parentExecutionContext);
            var command = CreateCommandForDescriptorByNamedParameters(executionContext, descriptor, holder, targetKey, namedParams);
            return ProcessAsyncCallForDescriptor(command, parentAction);
        }

        public ResultOfCalling CallAsyncForDecsriptorByPositionedParameters(GnuClayThreadExecutionContext parentExecutionContext, EntityAction parentAction, IValue holder, ulong descriptor, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var executionContext = CreateExecutionContext(parentExecutionContext);
            var command = CreateCommandForDescriptorByPositionedParameters(executionContext, descriptor, holder, targetKey, positionedParams);
            return ProcessAsyncCallForDescriptor(command, parentAction);
        }

        private GnuClayThreadExecutionContext CreateEmptyExecutionContext()
        {
            var executionContext = new GnuClayThreadExecutionContext();
            executionContext.ContextOfVariables = new ContextOfVariables(Context);
            var systemContextOfVariables = new ContextOfSystemVariables(Context);
            executionContext.ContextOfSystemVariables = systemContextOfVariables;
            systemContextOfVariables.Parent = mScriptExecutorEngine.ContextOfSystemVariables;
            return executionContext;
        }

        private GnuClayThreadExecutionContext CreateExecutionContext(GnuClayThreadExecutionContext parentExecutionContext)
        {
            var executionContext = new GnuClayThreadExecutionContext();
            executionContext.ContextOfVariables = new ContextOfVariables(Context);
            var systemContextOfVariables = new ContextOfSystemVariables(Context);
            executionContext.ContextOfSystemVariables = systemContextOfVariables;
            systemContextOfVariables.Parent = parentExecutionContext.ContextOfSystemVariables;
            return executionContext;
        }

        private Command CreateCommandByNamedParameters(GnuClayThreadExecutionContext executionContext, IValue function, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var command = NCreateCommandByNamedParameters(executionContext, holder, targetKey, namedParams);
            command.Function = function;
            return command;
        }

        private Command CreateCommandForDescriptorByNamedParameters(GnuClayThreadExecutionContext executionContext, ulong descriptor, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var command = NCreateCommandByNamedParameters(executionContext, holder, targetKey, namedParams);
            command.DescriptorOfFunction = descriptor;
            return command;
        }

        private Command NCreateCommandByNamedParameters(GnuClayThreadExecutionContext executionContext, IValue holder, ulong targetKey, List<NamedParamInfo> namedParams)
        {
            var command = NCreateCommand(executionContext, holder, targetKey);
            command.IsCallByNamedParams = true;
            command.NamedParams = namedParams;
            return command;
        }

        private Command CreateCommandByPositionedParameters(GnuClayThreadExecutionContext executionContext, IValue function, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var command = NCreateCommandByPositionedParameters(executionContext, holder, targetKey, positionedParams);
            command.Function = function;
            return command;
        }

        private Command CreateCommandForDescriptorByPositionedParameters(GnuClayThreadExecutionContext executionContext, ulong descriptor, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var command = NCreateCommandByPositionedParameters(executionContext, holder, targetKey, positionedParams);
            command.DescriptorOfFunction = descriptor;
            return command;
        }

        private Command NCreateCommandByPositionedParameters(GnuClayThreadExecutionContext executionContext, IValue holder, ulong targetKey, List<PositionParamInfo> positionedParams)
        {
            var command = NCreateCommand(executionContext, holder, targetKey);
            command.IsCallByNamedParams = false;
            command.PositionedParams = positionedParams;
            return command;
        }

        private Command NCreateCommand(GnuClayThreadExecutionContext executionContext, IValue holder, ulong targetKey)
        {
            var command = new Command();
            command.ExecutionContext = executionContext;

            if (holder == null)
            {
                holder = mCommonValuesFactory.SelfInstanceValue();
            }

            command.Holder = holder;
            command.TargetKey = targetKey;
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

        private ResultOfCalling InvokeSyncEntityAction(EntityAction action)
        {
            var command = action.Command;
            var targetExecutorsList = mCommandFiltersStorage.FindExecutors(command);

            if (_ListHelper.IsEmpty(targetExecutorsList))
            {
                action.Error = Context.ErrorsFactory.CreateUncaughtReferenceError();
                action.State = EntityActionState.Faulted;

                return CreateSyncResultOfCalling(action);
            }

            var targetExecutor = targetExecutorsList.FirstOrDefault();

            NormalizeCommandParams(command, targetExecutor);

            if (targetExecutor.IsUserDefined)
            {
                var result = new ResultOfCalling();
                result.Success = true;
                result.EntityAction = action;
                result.IsUserDefined = true;
                result.ExecutableCode = targetExecutor.FunctionModel;
                return result;
            }
        
            targetExecutor.Handler.Invoke(action);

            return CreateSyncResultOfCalling(action);
        }

        private void InvokeAsyncEntityAction(EntityAction action)
        {
            var command = action.Command;
            var targetExecutorsList = mCommandFiltersStorage.FindExecutors(command);

            if (_ListHelper.IsEmpty(targetExecutorsList))
            {
                action.Error = Context.ErrorsFactory.CreateUncaughtReferenceError();
                action.State = EntityActionState.Faulted;

                return;
            }

            var targetExecutor = targetExecutorsList.FirstOrDefault();
            NormalizeCommandParams(command, targetExecutor);

            if (targetExecutor.IsUserDefined)
            {
                var tmpNewInternalThreadExecutor = new InternalThreadExecutor(targetExecutor.FunctionModel, Context, command.ExecutionContext, action);
                ExecuteThread(tmpNewInternalThreadExecutor);
                return;
            }

            targetExecutor.Handler.Invoke(action);
        }

        private ResultOfCalling InvokeEntityActionByDescriptor(EntityAction action)
        {
            var command = action.Command;
            var targetExecutor = mCommandFiltersStorage.GetExecutorByDescriptor(command.DescriptorOfFunction);

            if(targetExecutor == null)
            {
                action.Error = Context.ErrorsFactory.CreateUncaughtReferenceError();
                action.State = EntityActionState.Faulted;
                return CreateSyncResultOfCalling(action);
            }

            NormalizeCommandParams(command, targetExecutor);

            if (targetExecutor.IsUserDefined)
            {
                var result = new ResultOfCalling();
                result.Success = true;
                result.EntityAction = action;
                result.IsUserDefined = true;
                result.ExecutableCode = targetExecutor.FunctionModel;
                return result;
            }

            targetExecutor.Handler.Invoke(action);

            return CreateSyncResultOfCalling(action);
        }

        private void InvokeAsyncEntityActionByDescriptor(EntityAction action)
        {
            var command = action.Command;
            var targetExecutor = mCommandFiltersStorage.GetExecutorByDescriptor(command.DescriptorOfFunction);

            if (targetExecutor == null)
            {
                action.Error = Context.ErrorsFactory.CreateUncaughtReferenceError();
                action.State = EntityActionState.Faulted;

                return;
            }

            NormalizeCommandParams(command, targetExecutor);

            if (targetExecutor.IsUserDefined)
            {
                var tmpNewInternalThreadExecutor = new InternalThreadExecutor(targetExecutor.FunctionModel, Context, command.ExecutionContext, action);
                ExecuteThread(tmpNewInternalThreadExecutor);
                return;
            }

            targetExecutor.Handler.Invoke(action);
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

            return InvokeSyncEntityAction(entityAction);
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

            Task.Run(() => {
                InvokeAsyncEntityAction(entityAction);
            });

            var result = new ResultOfCalling();
            result.Success = true;
            result.Result = entityAction;

            return result;
        }

        private ResultOfCalling ProcessSyncCallForDescriptor(Command command, EntityAction parentAction)
        {
            var entityAction = CreateEntityAction(command, parentAction);
            return InvokeEntityActionByDescriptor(entityAction);
        }

        private ResultOfCalling ProcessAsyncCallForDescriptor(Command command, EntityAction parentAction)
        {
            var entityAction = CreateEntityAction(command, parentAction);

            Task.Run(() => {
                InvokeAsyncEntityActionByDescriptor(entityAction);
            });

            var result = new ResultOfCalling();
            result.Success = true;
            result.Result = entityAction;

            return result;
        }

        public ulong AddFilter(CommandFilter filter)
        {
            return mCommandFiltersStorage.AddFilter(filter);
        }

        public void RemoveFilter(ulong descriptor)
        {
            mCommandFiltersStorage.RemoveFilter(descriptor);
        }

        private void ExecuteThread(InternalThreadExecutor executor)
        {
            lock(mCurrentExecutorsListLockObj)
            {
                mCurrentExecutorsList.Add(executor);
            }
            
            executor.Run();

            lock (mCurrentExecutorsListLockObj)
            {
                mCurrentExecutorsList.Remove(executor);
            }          
        }

        private object mCurrentExecutorsListLockObj = new object();
        private List<InternalThreadExecutor> mCurrentExecutorsList = new List<InternalThreadExecutor>();

        public object Save()
        {
            var result = new List<InternalThreadExecutorData>();

            foreach(var executor in mCurrentExecutorsList)
            {
                var data = executor.Save();
                result.Add(data);
            }

            return result;
        }

        public void Load(object value)
        {
            var itemsList = (List<InternalThreadExecutorData>)value;

            var tmpExecutors = new List<InternalThreadExecutor>();

            foreach(var item in itemsList)
            {
                tmpExecutors.Add(new InternalThreadExecutor(Context, item));
            }

            foreach(var item in tmpExecutors)
            {
                Task.Run(() => {
                    ExecuteThread(item);
                });
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
