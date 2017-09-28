using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.OperatorsSupport
{
    public class OperatorAddProvider : BaseGnuClayEngineComponent
    {
        public OperatorAddProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private StorageDataDictionary DataDictionary = null;
        private CommonKeysEngine CommonKeysEngine = null;
        private FunctionsEngine FunctionsEngine = null;
        private ConstTypeProvider ConstTypeProvider = null;

        public override void FirstInit()
        {
            DataDictionary = Context.DataDictionary;
            CommonKeysEngine = Context.CommonKeysEngine;
            FunctionsEngine = Context.FunctionsEngine;
            ConstTypeProvider = Context.ConstTypeProvider;
        }

        private ulong SelfInstanceKey = 0;
        private ulong AddOperatorKey = 0;
        private ulong FirstParamKey = 0;
        private ulong SecondParamKey = 0;
        private ulong NumberKey = 0;

        public override void SecondInit()
        {
            SelfInstanceKey = CommonKeysEngine.SelfInstanceKey;
            AddOperatorKey = CommonKeysEngine.AddOperatorKey;
            FirstParamKey = CommonKeysEngine.FirstParamKey;
            SecondParamKey = CommonKeysEngine.SecondParamKey;
            NumberKey = CommonKeysEngine.NumberKey;

            RegHandlerOfAdd();
        }

        private void RegHandlerOfAdd()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfAdd;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = AddOperatorKey;
            filter.TargetKey = 0;

            var filterParams = filter.Params;

            filterParams.Add(FirstParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            filterParams.Add(SecondParamKey, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = NumberKey
            });

            FunctionsEngine.AddFilter(filter);
        }

        private void HandlerOfAdd(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = (NumberValue)command.GetParamValue(FirstParamKey);
            var tmpParam_2 = (NumberValue)command.GetParamValue(SecondParamKey);
            action.Result = ConstTypeProvider.CreateConstValue(tmpParam_1.TypeKey, tmpParam_1.OriginalValue + tmpParam_2.OriginalValue);
            action.State = EntityActionState.Completed;
        }
    }
}
