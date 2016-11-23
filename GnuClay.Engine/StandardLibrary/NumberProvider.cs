using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GnuClay.Engine.ScriptExecutor.CommonData;

namespace GnuClay.Engine.StandardLibrary
{
    public class NumberProvider: BaseTypeProvider
    {
        public NumberProvider(GnuClayEngineComponentContext context)
            : base(context, StandartTypeNamesConstants.NumberName)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("NumberProvider");
        }

        protected override void OnRegType()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRegType `{TypeName}` `{TypeKey}`");
            RegType<NumberValue>();
            RegOperators();
        }

        public override IValue Create(object value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Create `{TypeName}` `{TypeKey}` `{value}`");

            return NCreate((double)value);
        }

        public NumberValue NCreate(double value)
        {
            return new NumberValue(ClassInfo, Context, value);
        }

        private void RegOperators()
        {
            Context.TypeProcessingContext.RegBinaryOperator(new BinaryOperatorRule()
            {
                FirstOperandType = TypeKey,
                SecondOperandType = TypeKey,
                OperatorHandler = AddNumber
            });
        }

        public IValue AddNumber(IValue firstOperand, IValue secondOperand)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("AddNumber");
            var tmpFirstOperand = (NumberValue)firstOperand;
            var tmpSecondOperand = (NumberValue)secondOperand;

            var tmpRez = Context.StandardLibrary.NumberProvider.NCreate(tmpFirstOperand.OriginalValue + tmpSecondOperand.OriginalValue);
            return tmpRez;
        }
    }
}
