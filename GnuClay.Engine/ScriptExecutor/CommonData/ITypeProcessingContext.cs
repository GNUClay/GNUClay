using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public delegate IValue BinaryOperatorHandler(IValue firstOperand, IValue secondOperand);

    public interface ITypeProcessingContext: IRunTimeTypeProcessingContext
    {
        GCSClassInfo RegType<T>(ITypeProvider provider);
        void RegExternalMethod(ExternalMethodInfo methodInfo);
        void RegBinaryOperator(BinaryOperatorRule rule);
    }
}
