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
        public ulong Key = 0;
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

            tmpSb.Append(nameof(Key));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Key.ToString());

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
