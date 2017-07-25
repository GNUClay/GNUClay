using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Inheritance
{
    public class ExecutorsQueueItem
    {
        public double Rank { get; set; }
        public ulong TypeKey { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(Rank)} = {Rank}");
            tmpSb.AppendLine($"{nameof(TypeKey)} = {TypeKey}");

            return tmpSb.ToString();
        }
    }
}
