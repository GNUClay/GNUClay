using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewCommandFilterParam: INewCommandFilterParam
    {
        public bool IsAnyType { get; set; } = true;
        public ulong TypeKey { get; set; } = 0;
        public bool IsAnyValue { get; set; } = true;
        public INewValue Value { get; set; } = null;

        public ulong GetLongHashCode()
        {
            ulong result = (ulong)IsAnyType.GetHashCode();

            result ^= TypeKey;

            result ^= (ulong)IsAnyValue.GetHashCode();

            if (Value != null)
            {
                result ^= Value.GetLongHashCode();
            }

            return result;
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintJsonToStringInformation(this);
        }
    }
}
