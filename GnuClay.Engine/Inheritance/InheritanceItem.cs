using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Inheritance
{
    [Serializable]
    public class InheritanceItem : IToStringData
    {
        public ulong SubKey = 0;
        public ulong SuperKey = 0;
        public double Rank = 0;
        public int Distance = 0;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public virtual string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(SubKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(SubKey.ToString());

            tmpSb.Append(nameof(SuperKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(SuperKey.ToString());

            tmpSb.Append(nameof(Rank));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Rank.ToString());

            tmpSb.Append(nameof(Distance));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Distance.ToString());

            return tmpSb.ToString();
        }
    }
}
