using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    [Serializable]
    public class InternalThreadExecutorData
    {
        public Stack<InternalFunctionExecutionModel> ExecutionFramesStack { get; set; }

        public override string ToString()
        {
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine("Begin InternalThreadExecutorData");
            foreach(var item in ExecutionFramesStack)
            {
                tmpSb.AppendLine(item.ToDbgString());
            }
            tmpSb.AppendLine("End InternalThreadExecutorData");
            return tmpSb.ToString();
        }
    }
}
