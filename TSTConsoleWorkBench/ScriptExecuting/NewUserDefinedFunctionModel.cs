using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewUserDefinedFunctionModel
    {
        public CommandFilter Filter { get; set; }
        public FunctionModel FunctionModel { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(Filter)} = {Filter}");
            tmpSb.AppendLine($"{nameof(FunctionModel)} = {FunctionModel}");

            return tmpSb.ToString();
        }
    }
}
