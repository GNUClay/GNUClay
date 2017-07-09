using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewCommand: INewLongHashableObject
    {
        public NewGnuClayThreadExecutionContext ExecutionContext { get; set; }
        public INewValue Function { get; set; }
        public INewValue Holder { get; set; }
        public ulong TargetKey { get; set; }
        public List<NewPositionParamInfo> PositionedParams { get; set; }
        public List<NewNamedParamInfo> NamedParams { get; set; }
        public bool IsCallByNamedParams { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }

        public ulong GetLongHashCode()
        {
            ulong result = 0;

            if(Function != null)
            {
                result ^= Function.GetLongHashCode();
            }

            if(Holder != null)
            {
                result ^= Holder.GetLongHashCode();
            }

            result ^= TargetKey;

            if(PositionedParams != null)
            {
                foreach (var paramItem in PositionedParams)
                {
                    result ^= paramItem.GetLongHashCode();
                }
            }

            if(NamedParams != null)
            {
                foreach (var paramItem in NamedParams)
                {
                    result ^= paramItem.GetLongHashCode();
                }
            }

            return result;
        }
    }
}
