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
    public class ArithmeticOperatorsProvider : BaseGnuClayEngineComponent
    {
        public ArithmeticOperatorsProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private StorageDataDictionary DataDictionary;
        private CommonKeysEngine CommonKeysEngine;
        private FunctionsEngine FunctionsEngine;
        private ConstTypeProvider ConstTypeProvider;

        public override void FirstInit()
        {
            DataDictionary = Context.DataDictionary;
            CommonKeysEngine = Context.CommonKeysEngine;
            FunctionsEngine = Context.FunctionsEngine;
            ConstTypeProvider = Context.ConstTypeProvider;
        }

        private ulong SelfInstanceKey;
        private ulong AddOperatorKey;
        private ulong SubOperatorKey;
        private ulong MulOperatorKey;
        private ulong DivOperatorKey;
        private ulong FirstParamKey;
        private ulong SecondParamKey;
        private ulong NumberKey;

        public override void SecondInit()
        {
            SelfInstanceKey = CommonKeysEngine.SelfInstanceKey;
            AddOperatorKey = CommonKeysEngine.AddOperatorKey;
            SubOperatorKey = CommonKeysEngine.SubOperatorKey;
            MulOperatorKey = CommonKeysEngine.MulOperatorKey;
            DivOperatorKey = CommonKeysEngine.DivOperatorKey;
            FirstParamKey = CommonKeysEngine.FirstParamKey;
            SecondParamKey = CommonKeysEngine.SecondParamKey;
            NumberKey = CommonKeysEngine.NumberKey;

            RegHandlerOfAdd();
            RegHandlerOfSub();
            RegHandlerOfMul();
            RegHandlerOfDiv();
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

        private void RegHandlerOfSub()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfSub;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = SubOperatorKey;
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

        private void HandlerOfSub(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = (NumberValue)command.GetParamValue(FirstParamKey);
            var tmpParam_2 = (NumberValue)command.GetParamValue(SecondParamKey);
            action.Result = ConstTypeProvider.CreateConstValue(tmpParam_1.TypeKey, tmpParam_1.OriginalValue - tmpParam_2.OriginalValue);
            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfMul()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfMul;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = MulOperatorKey;
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

        private void HandlerOfMul(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = (NumberValue)command.GetParamValue(FirstParamKey);
            var tmpParam_2 = (NumberValue)command.GetParamValue(SecondParamKey);
            action.Result = ConstTypeProvider.CreateConstValue(tmpParam_1.TypeKey, tmpParam_1.OriginalValue * tmpParam_2.OriginalValue);
            action.State = EntityActionState.Completed;
        }

        private void RegHandlerOfDiv()
        {
            var filter = new CommandFilter();
            filter.Handler = HandlerOfDiv;
            filter.HolderKey = SelfInstanceKey;
            filter.FunctionKey = DivOperatorKey;
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

        private void HandlerOfDiv(EntityAction action)
        {
            var command = action.Command;
            var tmpParam_1 = (NumberValue)command.GetParamValue(FirstParamKey);
            var tmpParam_2 = (NumberValue)command.GetParamValue(SecondParamKey);
            action.Result = ConstTypeProvider.CreateConstValue(tmpParam_1.TypeKey, tmpParam_1.OriginalValue / tmpParam_2.OriginalValue);
            action.State = EntityActionState.Completed;
        }
    }
}
