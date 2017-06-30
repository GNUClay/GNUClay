using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewNamedParamInfo
    {
        public INewValue ParamName { get; set; }
        public INewValue ParamValue { get; set; }

        public override string ToString()
        {
            return $"{nameof(ParamName)} = {ParamName}; {nameof(ParamValue)} = {ParamValue}";
        }
    }
}
