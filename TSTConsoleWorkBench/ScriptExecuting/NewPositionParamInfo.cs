using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewPositionParamInfo
    {
        public INewValue ParamValue { get; set; }
        public int Position { get; set; }

        public override string ToString()
        {
            return $"{nameof(ParamValue)} = {ParamValue}; {nameof(Position)} = {Position}";
        }
    }
}
