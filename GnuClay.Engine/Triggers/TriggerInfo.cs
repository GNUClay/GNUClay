using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Triggers
{
    public class TriggerInfo
    {
        public KindOfTrigger Kind = KindOfTrigger.Undefined;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(Kind)} = {Kind}");

            return tmpSb.ToString();
        }
    }
}
