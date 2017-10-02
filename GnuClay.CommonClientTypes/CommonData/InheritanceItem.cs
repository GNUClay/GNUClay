using System;
using System.Text;
using GnuClay.CommonUtils.TypeHelpers;

namespace GnuClay.CommonClientTypes.CommonData
{
    [Serializable]
    public class InheritanceItem : ISmartToString
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
            return ToString(null, 0);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine($"{spacesString}Begin InheritanceItem");
            tmpSb.AppendLine($"{nameof(SubKey)} = {SubKey}");
            if (dataDictionary != null && SubKey > 0)
            {
                tmpSb.AppendLine($"{spacesString}SubTypeName = {dataDictionary.GetValue(SubKey)}");
            }
            tmpSb.AppendLine($"{nameof(SuperKey)} = {SuperKey}");
            if (dataDictionary != null && SuperKey > 0)
            {
                tmpSb.AppendLine($"{spacesString}SuperTypeName = {dataDictionary.GetValue(SuperKey)}");
            }
            tmpSb.AppendLine($"{nameof(Rank)} = {Rank}");
            tmpSb.AppendLine($"{nameof(Distance)} = {Distance}");
            tmpSb.AppendLine($"{spacesString}End InheritanceItem");
            return tmpSb.ToString();
        }
    }
}
