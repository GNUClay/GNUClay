using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    [Serializable]
    public class NamedParamInfo : ILongHashableObject
    {
        public IValue ParamName { get; set; }
        public IValue ParamValue { get; set; }

        public ulong GetLongHashCode()
        {
            ulong result = 0;

            if (ParamName != null)
            {
                result ^= ParamName.GetLongHashCode();
            }

            if (ParamValue != null)
            {
                result ^= ParamValue.GetLongHashCode();
            }

            return result;
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"{nameof(ParamName)} = {ParamName}; {nameof(ParamValue)} = {ParamValue}";
        }
    }
}
