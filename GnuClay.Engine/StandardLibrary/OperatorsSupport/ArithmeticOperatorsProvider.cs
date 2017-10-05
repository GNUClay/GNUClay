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
        private CommonValuesFactory CommonValuesFactory;
        private CommonKeysEngine CommonKeysEngine;
        private FunctionsEngine FunctionsEngine;
        private ConstTypeProvider ConstTypeProvider;

        public override void FirstInit()
        {
            DataDictionary = Context.DataDictionary;
            CommonValuesFactory = Context.CommonValuesFactory;
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
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if(tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.NullValue();
                action.State = EntityActionState.Completed;
                return;
            }

            var tmpParamNumberValue_1 = (NumberValue)tmpParam_1;
            var tmpParamNumberValue_2 = (NumberValue)tmpParam_2;
            action.Result = ConstTypeProvider.CreateConstValue(tmpParamNumberValue_1.TypeKey, tmpParamNumberValue_1.OriginalValue + tmpParamNumberValue_2.OriginalValue);
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
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.NullValue();
                action.State = EntityActionState.Completed;
                return;
            }

            var tmpParamNumberValue_1 = (NumberValue)tmpParam_1;
            var tmpParamNumberValue_2 = (NumberValue)tmpParam_2;
            action.Result = ConstTypeProvider.CreateConstValue(tmpParam_1.TypeKey, tmpParamNumberValue_1.OriginalValue - tmpParamNumberValue_2.OriginalValue);
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
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.NullValue();
                action.State = EntityActionState.Completed;
                return;
            }

            var tmpParamNumberValue_1 = (NumberValue)tmpParam_1;
            var tmpParamNumberValue_2 = (NumberValue)tmpParam_2;
            action.Result = ConstTypeProvider.CreateConstValue(tmpParam_1.TypeKey, tmpParamNumberValue_1.OriginalValue * tmpParamNumberValue_2.OriginalValue);
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
            var tmpParam_1 = command.GetParamValue(FirstParamKey);
            var tmpParam_2 = command.GetParamValue(SecondParamKey);

            if (tmpParam_1.IsNull || tmpParam_2.IsNull)
            {
                action.Result = CommonValuesFactory.NullValue();
                action.State = EntityActionState.Completed;
                return;
            }

            var tmpParamNumberValue_1 = (NumberValue)tmpParam_1;
            var tmpParamNumberValue_2 = (NumberValue)tmpParam_2;

            var tmpParam_2_OriginalValue = tmpParamNumberValue_2.OriginalValue;

            if(tmpParam_2_OriginalValue == 0)
            {
                action.Result = CommonValuesFactory.NullValue();
                action.State = EntityActionState.Completed;
                return;
            }

            action.Result = ConstTypeProvider.CreateConstValue(tmpParam_1.TypeKey, tmpParamNumberValue_1.OriginalValue / tmpParam_2_OriginalValue);
            action.State = EntityActionState.Completed;
        }
    }
}
