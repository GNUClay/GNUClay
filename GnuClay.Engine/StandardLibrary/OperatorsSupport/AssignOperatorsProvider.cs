using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
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

        public override void FirstInit()
        {
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
            if (leftParam.IsVariable)
            {
                leftParam.ValueFromContainer = rightParam;
                action.Result = rightParam;
                action.State = EntityActionState.Completed;
                return;
            }
            if (leftParam.IsProperty)
            {
                if (leftParam.Kind == KindOfValue.Logical)
                {
                    var resultOfCalling = leftParam.ExecuteSetLogicalProperty(rightParam, KindOfLogicalOperator.RewriteFactReturnValue);
                    action.AppendResultOfResultOfCalling(resultOfCalling);
                    return;
                }
                try
                {
                    leftParam.ValueFromContainer = rightParam;
                    action.Result = rightParam;
                    action.State = EntityActionState.Completed;
                    return;
                }
                catch (InternalCallException ice)
                {
                    action.AppendResultOfResultOfCalling(ice.ToResultOfCalling());
                    return;
                }
            }

            throw new NotImplementedException();
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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfPlusAssing action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfMinusAssing action = {action?.ToString(DataDictionary, 0)}");
#endif

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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfMulAssing action = {action?.ToString(DataDictionary, 0)}");
#endif

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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfDivAssing action = {action?.ToString(DataDictionary, 0)}");
#endif

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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfAssingFact action = {action?.ToString(DataDictionary, 0)}");
#endif

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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfPlusAssingFact action = {action?.ToString(DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }
    }
}
