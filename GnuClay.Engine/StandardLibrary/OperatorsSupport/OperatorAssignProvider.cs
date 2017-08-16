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
    public class OperatorAssignProvider: BaseGnuClayEngineComponent
    {
        public OperatorAssignProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private StorageDataDictionary DataDictionary = null;
        private CommonKeysEngine CommonKeysEngine = null;
        private FunctionsEngine FunctionsEngine = null;

        public override void FirstInit()
        {
            DataDictionary = Context.DataDictionary;
            CommonKeysEngine = Context.CommonKeysEngine;
            FunctionsEngine = Context.FunctionsEngine;
        }

        private ulong SelfKey = 0;
        private ulong AssignOperatorKey = 0;
        private ulong FirstParamKey = 0;
        private ulong SecondParamKey = 0;

        public override void SecondInit()
        {
            SelfKey = CommonKeysEngine.SelfKey;
            AssignOperatorKey = CommonKeysEngine.AssignOperatorKey;
            FirstParamKey = CommonKeysEngine.FirstParamKey;
            SecondParamKey = CommonKeysEngine.SecondParamKey;

            RegHandlerOfAssign();
        }

        private void RegHandlerOfAssign()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfAssign;
            filter.HolderKey = SelfKey;
            filter.FunctionKey = AssignOperatorKey;

            filter.Params.Add(FirstParamKey, new CommandFilterParam()
            {
            });

            filter.Params.Add(SecondParamKey, new CommandFilterParam()
            {
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfAssign(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfAssign action = {action}");

            var command = action.Command;

            NLog.LogManager.GetCurrentClassLogger().Info($"Begin HandlerOfAssign command = {command}");

            NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign FirstParamKey = {FirstParamKey} SecondParamKey = {SecondParamKey}");

            var leftParam = command.GetParam(FirstParamKey);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign -> GetParamValue");
#endif

            var rightParam = command.GetParamValue(SecondParamKey);

            NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign leftParam = {leftParam}");
            NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign rightParam = {rightParam}");

            if (leftParam.IsVariable)
            {
                leftParam.ValueFromContainer = rightParam;
                action.Result = rightParam;
                action.State = EntityActionState.Completed;

                NLog.LogManager.GetCurrentClassLogger().Info($"End HandlerOfAssign (1) action = {action}");

                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"NEXT HandlerOfAssign action = {action}");

            if (leftParam.IsProperty)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign IsProperty action = {action}");

                if (leftParam.Kind == KindOfValue.Logical)
                {
                    var resultOfCalling = leftParam.ExecuteSetLogicalProperty(rightParam, KindOfLogicalOperator.RewriteFactReturnValue);

                    NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign resultOfCalling = {resultOfCalling}");

                    action.AppendResultOfResultOfCalling(resultOfCalling);

                    return;
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"HandlerOfAssign NEXT IsProperty action = {action}");

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
    }
}
