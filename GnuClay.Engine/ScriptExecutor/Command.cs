using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class Command : ILongHashableObject
    {
        public GnuClayThreadExecutionContext ExecutionContext { get; set; }
        public IValue Function { get; set; }
        public IValue Holder { get; set; }
        public ulong TargetKey { get; set; }
        public List<PositionParamInfo> PositionedParams { get; set; }
        public List<NamedParamInfo> NamedParams { get; set; }
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

            if (Function != null)
            {
                result ^= Function.GetLongHashCode();
            }

            if (Holder != null)
            {
                result ^= Holder.GetLongHashCode();
            }

            result ^= TargetKey;

            if (PositionedParams != null)
            {
                foreach (var paramItem in PositionedParams)
                {
                    result ^= paramItem.GetLongHashCode();
                }
            }

            if (NamedParams != null)
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
