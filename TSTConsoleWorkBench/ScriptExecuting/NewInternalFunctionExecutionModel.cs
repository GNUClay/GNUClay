using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewInternalFunctionExecutionModel
    {
        public NewInternalFunctionExecutionModel(FunctionModel source)
        {
            mFunction = source;
        }

        private FunctionModel mFunction = null;

        public ScriptCommand FirstCommand
        {
            get
            {
                return mFunction.FirstCommand;
            }
        }

        public ScriptCommand this[int lineNumber]
        {
            get
            {
                return mFunction[lineNumber];
            }
        }

        public Stack<INewValue> ValuesStack { get; set; } = new Stack<INewValue>();

        public void BeginCall()
        {
            FunctionKey = 0;
            Target = 0;
            IsCalledByNamedParameters = null;
        }

        public ulong FunctionKey { get; set; }
        public ulong Target { get; set; }
        public bool? IsCalledByNamedParameters = null;
        public bool? IsSetParamName = false;

        public string ToDbgString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine("Begin ValuesStack");

            foreach (var val in ValuesStack)
            {
                tmpSb.AppendLine(val.ToString());
            }

            tmpSb.AppendLine("End ValuesStack");

            tmpSb.AppendLine($"{nameof(FunctionKey)} {FunctionKey}");
            tmpSb.AppendLine($"{nameof(Target)} {Target}");
            tmpSb.AppendLine($"{nameof(IsCalledByNamedParameters)} {IsCalledByNamedParameters}");
            tmpSb.AppendLine($"{nameof(IsSetParamName)} {IsSetParamName}");

            return tmpSb.ToString();
        }
    }
}
