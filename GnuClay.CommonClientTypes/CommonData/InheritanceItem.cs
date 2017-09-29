using System;
using System.Text;
using GnuClay.CommonUtils.TypeHelpers;

namespace GnuClay.CommonClientTypes.CommonData
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

            tmpSb.AppendLine($"{nameof(SubKey)} = {SubKey}");
            tmpSb.AppendLine($"{nameof(SuperKey)} = {SuperKey}");
            tmpSb.AppendLine($"{nameof(Rank)} = {Rank}");
            tmpSb.AppendLine($"{nameof(Distance)} = {Distance}");

            return tmpSb.ToString();
        }
    }
}
