using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class SpecialOperator
    {
        public ulong FunctionKey { get; set; }
        public KindOfLogicalOperator KindOfLogicalOperator { get; set; } = KindOfLogicalOperator.Unknown;


        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var tmpSb = new StringBuilder();

            return tmpSb.ToString();
        }
    }
}
