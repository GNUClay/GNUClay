using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewPositionParamInfo: INewLongHashableObject
    {
        public INewValue ParamValue { get; set; }
        public int Position { get; set; }

        public ulong GetLongHashCode()
        {
            var result = (ulong)Position;

            if (ParamValue != null)
            {
                result ^= ParamValue.GetLongHashCode();
            }

            return result;
        }

        public override string ToString()
        {
            return $"{nameof(ParamValue)} = {ParamValue}; {nameof(Position)} = {Position}";
        }
    }
}
