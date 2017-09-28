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

        private ulong SelfInstanceKey = 0;
        private ulong AssignOperatorKey = 0;
        private ulong FirstParamKey = 0;
        private ulong SecondParamKey = 0;

        public override void SecondInit()
        {
            SelfInstanceKey = CommonKeysEngine.SelfInstanceKey;
            AssignOperatorKey = CommonKeysEngine.AssignOperatorKey;
            FirstParamKey = CommonKeysEngine.FirstParamKey;
            SecondParamKey = CommonKeysEngine.SecondParamKey;

            RegHandlerOfAssign();
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
    }
}
