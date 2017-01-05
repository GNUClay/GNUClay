using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Inheritance
{
    [Serializable]
    public class InheritanceInfo : IToStringData
    {
        public double Rank = 0;
        public InheritanceAspect Aspect = InheritanceAspect.Unknown;

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
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(Rank));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Rank.ToString());

            tmpSb.Append(nameof(Aspect));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Aspect.ToString());

            return tmpSb.ToString();
        }
    }
}
