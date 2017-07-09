using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewNamedParamInfo : INewLongHashableObject
    {
        public INewValue ParamName { get; set; }
        public INewValue ParamValue { get; set; }

        public ulong GetLongHashCode()
        {
            ulong result = 0;

            if(ParamName != null)
            {
                result ^= ParamName.GetLongHashCode();
            }

            if (ParamValue != null)
            {
                result ^= ParamValue.GetLongHashCode();
            }

            return result;
        }

        public override string ToString()
        {
            return $"{nameof(ParamName)} = {ParamName}; {nameof(ParamValue)} = {ParamValue}";
        }
    }
}
