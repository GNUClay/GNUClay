using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    public class ResultOfCalling
    {
        public bool IsUserDefined { get; set; }
        public FunctionModel ExecutableCode { get; set; }
        public EntityAction EntityAction { get; set; }
        public bool Success { get; set; }
        public IValue Result { get; set; }
        public IValue Error { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{nameof(IsUserDefined)} = {IsUserDefined}");
            sb.AppendLine($"{nameof(ExecutableCode)} = {ExecutableCode}");
            sb.AppendLine($"{nameof(EntityAction)} = {EntityAction}");
            sb.AppendLine($"{nameof(Success)} = {Success}");
            sb.AppendLine($"{nameof(Result)} = {Result}");
            sb.AppendLine($"{nameof(Error)} = {Error}");

            return sb.ToString();
        }
    }
}
