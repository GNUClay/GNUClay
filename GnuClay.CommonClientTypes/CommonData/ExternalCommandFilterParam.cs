using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    public class ExternalCommandFilterParam: IExternalCommandFilterParam
    {
        public bool IsAnyType { get; set; } = true;
        public ulong TypeKey { get; set; }

        /// <summary>
        /// Serves as the hash function that has size as ulong.
        /// </summary>
        /// <returns>Return value of the hash.</returns>
        public virtual ulong GetLongHashCode()
        {
            ulong result = (ulong)IsAnyType.GetHashCode();
            result ^= TypeKey;
            return result;
        }

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
            tmpSb.AppendLine($"{spacesString}Begin ExternalCommandFilterParam");
            tmpSb.AppendLine($"{spacesString}{nameof(IsAnyType)} = {IsAnyType}");
            tmpSb.AppendLine($"{spacesString}{nameof(TypeKey)} = {TypeKey}");
            if (dataDictionary != null && TypeKey > 0)
            {
                tmpSb.AppendLine($"{spacesString}TypeName = {dataDictionary.GetValue(TypeKey)}");
            }
            tmpSb.AppendLine($"{spacesString}End ExternalCommandFilterParam");
            return tmpSb.ToString();
        }
    }
}
