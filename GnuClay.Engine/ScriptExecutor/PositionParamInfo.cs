using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class PositionParamInfo: ILongHashableObject
    {
        public IValue ParamValue { get; set; }
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

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"{nameof(ParamValue)} = {ParamValue}; {nameof(Position)} = {Position}";
        }
    }
}
