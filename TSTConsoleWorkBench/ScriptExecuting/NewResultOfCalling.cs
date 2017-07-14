using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewResultOfCalling
    {
        public bool Success { get; set; }
        public INewValue Result { get; set; }
        public INewValue Error { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{nameof(Success)} = {Success}");
            sb.AppendLine($"{nameof(Result)} = {Result}");
            sb.AppendLine($"{nameof(Error)} = {Error}");

            return sb.ToString();
        }
    }
}
