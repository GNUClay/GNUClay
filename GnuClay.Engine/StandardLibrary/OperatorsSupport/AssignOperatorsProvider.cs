using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.OperatorsSupport
{
    public class AssignOperatorsProvider: BaseGnuClayEngineComponent
    {
        public AssignOperatorsProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private StorageDataDictionary DataDictionary;
        private CommonKeysEngine CommonKeysEngine;
        private FunctionsEngine FunctionsEngine;
        private CommonValuesFactory mCommonValuesFactory;

        public override void FirstInit()
        {
            mCommonValuesFactory = Context.CommonValuesFactory;
            DataDictionary = Context.DataDictionary;
            CommonKeysEngine = Context.CommonKeysEngine;
            FunctionsEngine = Context.FunctionsEngine;
        }

        private ulong SelfInstanceKey;
        private ulong AssignOperatorKey;
        private ulong PlusAssingOperatorKey;
        private ulong MinusAssingOperatorKey;
        private ulong MulAssingOperatorKey;
        private ulong DivAssingOperatorKey;
        private ulong AssingFactOperatorKey;
        private ulong PlusAssingFactOperatorKey;
        private ulong FirstParamKey;
        private ulong SecondParamKey;
        private ulong EntityActionTypeKey;
        private ulong AddOperatorKey;
        private ulong SubOperatorKey;
        private ulong MulOperatorKey;
        private ulong DivOperatorKey;

        public override void SecondInit()
        {
            SelfInstanceKey = CommonKeysEngine.SelfInstanceKey;
            AssignOperatorKey = CommonKeysEngine.AssignOperatorKey;
            PlusAssingOperatorKey = CommonKeysEngine.PlusAssingOperatorKey;
            MinusAssingOperatorKey = CommonKeysEngine.MinusAssingOperatorKey;
            MulAssingOperatorKey = CommonKeysEngine.MulAssingOperatorKey;
            DivAssingOperatorKey = CommonKeysEngine.DivAssingOperatorKey;
            AssingFactOperatorKey = CommonKeysEngine.AssingFactOperatorKey;
            PlusAssingFactOperatorKey = CommonKeysEngine.PlusAssingFactOperatorKey;
            FirstParamKey = CommonKeysEngine.FirstParamKey;
            SecondParamKey = CommonKeysEngine.SecondParamKey;
            EntityActionTypeKey = CommonKeysEngine.EntityActionTypeKey;
            AddOperatorKey = CommonKeysEngine.AddOperatorKey;
            SubOperatorKey = CommonKeysEngine.SubOperatorKey;
            MulOperatorKey = CommonKeysEngine.MulOperatorKey;
            DivOperatorKey = CommonKeysEngine.DivOperatorKey;

            RegHandlerOfAssign();
            RegHandlerOfPlusAssing();
            RegHandlerOfMinusAssing();
            RegHandlerOfMulAssing();
            RegHandlerOfDivAssing();
            RegHandlerOfAssingFact();
            RegHandlerOfPlusAssingFact();
        }

        private void RegHandlerOfAssign()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfAssign;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = AssignOperatorKey;
            var filterParams = filter.Params;
            filterParams.Add(FirstParamKey, new CommandFilterParam(){});
            filterParams.Add(SecondParamKey, new CommandFilterParam(){});
            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfAssign(EntityAction action)
        {
            var command = action.Command;
            var leftParam = command.GetParam(FirstParamKey);
            var rightParam = command.GetParamValue(SecondParamKey);

//#if DEBUG
//            NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign leftParam = {leftParam.ToString(DataDictionary, 0)}");
//            NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign rightParam = {rightParam.ToString(DataDictionary, 0)}");
//#endif

            if (leftParam.IsVariable || (leftParam.IsProperty && leftParam.Kind != KindOfValue.Logical))
            {
                try
                {
                    NAssing(leftParam, rightParam, action);
                    return;
                }
                catch (InternalCallException ice)
                {
                    action.AppendResultFromResultOfCalling(ice.ToResultOfCalling());
                    return;
                }
            }

            if(leftParam.IsProperty && leftParam.Kind == KindOfValue.Logical)
            {
                var resultOfCalling = leftParam.ExecuteSetLogicalProperty(rightParam, KindOfLogicalOperator.RewriteFactReturnValue);
                action.AppendResultFromResultOfCalling(resultOfCalling);
                return;
            }

            throw new NotImplementedException();
        }

        private void NAssing(IValue leftParam, IValue rightParam, EntityAction action)
        {
            leftParam.ValueFromContainer = rightParam;
            action.Result = rightParam;
            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfPlusAssing()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfPlusAssing;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = PlusAssingOperatorKey;
            filter.TargetKey = 0;
            var filterParams = filter.Params;
            filterParams.Add(FirstParamKey, new CommandFilterParam());
            filterParams.Add(SecondParamKey, new CommandFilterParam());
            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfPlusAssing(EntityAction action)
        {
            var command = action.Command;
            var leftParam = command.GetParam(FirstParamKey);
            var rightParam = command.GetParamValue(SecondParamKey);

            if(leftParam.IsVariable || (leftParam.IsProperty && leftParam.Kind != KindOfValue.Logical))
            {
                try
                {
                    NRunOperationAndAssingNext(leftParam, rightParam, action, AddOperatorKey);
                    return;
                }
                catch (InternalCallException ice)
                {
                    action.AppendResultFromResultOfCalling(ice.ToResultOfCalling());
                    return;
                }
            }

            if (leftParam.IsProperty && leftParam.Kind == KindOfValue.Logical)
            {
                var resultOfCalling = leftParam.ExecuteSetLogicalProperty(rightParam, KindOfLogicalOperator.WriteFactReturnValue);
                action.AppendResultFromResultOfCalling(resultOfCalling);
                return;
            }

            throw new NotImplementedException();
        }

        private void NRunOperationAndAssingNext(IValue leftParam, IValue rightParam, EntityAction action, ulong targetOperationKey)
        {
            var command = action.Command;

            var opCommand = new Command();
            opCommand.ExecutionContext = command.ExecutionContext;
            opCommand.Holder = command.Holder;
            opCommand.IsCallByNamedParams = true;
            opCommand.Function = new EntityValue(targetOperationKey);

            var opNamedParams = new List<NamedParamInfo>();
            opCommand.NamedParams = opNamedParams;

            foreach (var param in command.NamedParams)
            {
                opNamedParams.Add(param);
            }

            opCommand.CreateParamsDict();

            var opAction = mCommonValuesFactory.CreateEntityAction(opCommand, action);
            var opResult = FunctionsEngine.InvokeSyncEntityAction(opAction);

            if (!opResult.Success)
            {
                throw new InternalCallException(opResult.Error);
            }

            NAssing(leftParam, opResult.Result, action);
        }

        private void RegHandlerOfMinusAssing()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfMinusAssing;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = MinusAssingOperatorKey;
            filter.TargetKey = 0;
            var filterParams = filter.Params;
            filterParams.Add(FirstParamKey, new CommandFilterParam());
            filterParams.Add(SecondParamKey, new CommandFilterParam());
            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfMinusAssing(EntityAction action)
        {
            var command = action.Command;
            var leftParam = command.GetParam(FirstParamKey);
            var rightParam = command.GetParamValue(SecondParamKey);

            if (leftParam.IsVariable || (leftParam.IsProperty && leftParam.Kind != KindOfValue.Logical))
            {
                try
                {
                    NRunOperationAndAssingNext(leftParam, rightParam, action, SubOperatorKey);
                    return;
                }
                catch (InternalCallException ice)
                {
                    action.AppendResultFromResultOfCalling(ice.ToResultOfCalling());
                    return;
                }
            }

            if (leftParam.IsProperty && leftParam.Kind == KindOfValue.Logical)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        private void RegHandlerOfMulAssing()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfMulAssing;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = MulAssingOperatorKey;
            filter.TargetKey = 0;
            var filterParams = filter.Params;
            filterParams.Add(FirstParamKey, new CommandFilterParam());
            filterParams.Add(SecondParamKey, new CommandFilterParam());
            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfMulAssing(EntityAction action)
        {
            var command = action.Command;
            var leftParam = command.GetParam(FirstParamKey);
            var rightParam = command.GetParamValue(SecondParamKey);

            if (leftParam.IsVariable || (leftParam.IsProperty && leftParam.Kind != KindOfValue.Logical))
            {
                try
                {
                    NRunOperationAndAssingNext(leftParam, rightParam, action, MulOperatorKey);
                    return;
                }
                catch (InternalCallException ice)
                {
                    action.AppendResultFromResultOfCalling(ice.ToResultOfCalling());
                    return;
                }
            }

            if (leftParam.IsProperty && leftParam.Kind == KindOfValue.Logical)
            {
                var resultOfCalling = leftParam.ExecuteSetLogicalProperty(rightParam, KindOfLogicalOperator.WriteFactReturnValue);
                action.AppendResultFromResultOfCalling(resultOfCalling);
                return;
            }

            throw new NotImplementedException();
        }

        private void RegHandlerOfDivAssing()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfDivAssing;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = DivAssingOperatorKey;
            filter.TargetKey = 0;
            var filterParams = filter.Params;
            filterParams.Add(FirstParamKey, new CommandFilterParam());
            filterParams.Add(SecondParamKey, new CommandFilterParam());
            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfDivAssing(EntityAction action)
        {
            var command = action.Command;
            var leftParam = command.GetParam(FirstParamKey);
            var rightParam = command.GetParamValue(SecondParamKey);

            if (leftParam.IsVariable || (leftParam.IsProperty && leftParam.Kind != KindOfValue.Logical))
            {
                try
                {
                    NRunOperationAndAssingNext(leftParam, rightParam, action, DivOperatorKey);
                    return;
                }
                catch (InternalCallException ice)
                {
                    action.AppendResultFromResultOfCalling(ice.ToResultOfCalling());
                    return;
                }
            }

            if (leftParam.IsProperty && leftParam.Kind == KindOfValue.Logical)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }

        private void RegHandlerOfAssingFact()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfAssingFact;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = AssingFactOperatorKey;
            filter.TargetKey = 0;
            var filterParams = filter.Params;
            filterParams.Add(FirstParamKey, new CommandFilterParam());
            filterParams.Add(SecondParamKey, new CommandFilterParam());
            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfAssingFact(EntityAction action)
        {
            var command = action.Command;
            var leftParam = command.GetParam(FirstParamKey);
            var rightParam = command.GetParamValue(SecondParamKey);

            if (leftParam.IsVariable || (leftParam.IsProperty && leftParam.Kind != KindOfValue.Logical))
            {
                try
                {
                    NAssing(leftParam, rightParam, action);
                    return;
                }
                catch (InternalCallException ice)
                {
                    action.AppendResultFromResultOfCalling(ice.ToResultOfCalling());
                    return;
                }
            }

            if (leftParam.IsProperty && leftParam.Kind == KindOfValue.Logical)
            {
                var resultOfCalling = leftParam.ExecuteSetLogicalProperty(rightParam, KindOfLogicalOperator.RewriteFactReturnThisFact);
                action.AppendResultFromResultOfCalling(resultOfCalling);
                return;
            }

            throw new NotImplementedException();
        }

        private void RegHandlerOfPlusAssingFact()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfPlusAssingFact;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = PlusAssingFactOperatorKey;
            filter.TargetKey = 0;
            var filterParams = filter.Params;
            filterParams.Add(FirstParamKey, new CommandFilterParam());
            filterParams.Add(SecondParamKey, new CommandFilterParam());
            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfPlusAssingFact(EntityAction action)
        {
            var command = action.Command;
            var leftParam = command.GetParam(FirstParamKey);
            var rightParam = command.GetParamValue(SecondParamKey);

            if (leftParam.IsVariable || (leftParam.IsProperty && leftParam.Kind != KindOfValue.Logical))
            {
                try
                {
                    NRunOperationAndAssingNext(leftParam, rightParam, action, AddOperatorKey);
                    return;
                }
                catch (InternalCallException ice)
                {
                    action.AppendResultFromResultOfCalling(ice.ToResultOfCalling());
                    return;
                }
            }

            if (leftParam.IsProperty && leftParam.Kind == KindOfValue.Logical)
            {
                var resultOfCalling = leftParam.ExecuteSetLogicalProperty(rightParam, KindOfLogicalOperator.WriteFactReturnThisFact);
                action.AppendResultFromResultOfCalling(resultOfCalling);
                return;
            }

            throw new NotImplementedException();
        }
    }
}
