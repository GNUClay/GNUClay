using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Inheritance
{
    public class TwoKeysInheritanceItem: InheritanceItem
    {
        public ulong SubKey;
             
        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(base.ToStringData());

            tmpSb.Append(nameof(SubKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(SubKey.ToString());

            return tmpSb.ToString();
        }
    }
}
