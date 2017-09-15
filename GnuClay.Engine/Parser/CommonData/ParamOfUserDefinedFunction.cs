using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.CommonData
{
    public class ParamOfUserDefinedFunction
    {
        public ulong NameKey { get; set; }
        public ulong TypeKey { get; set; }

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
            var nextIndent = indent + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spacesString}Begin ParamOfUserDefinedFunction");
            sb.AppendLine($"{spacesString}{nameof(NameKey)} = {NameKey}");
            if (dataDictionary != null)
            {
                sb.AppendLine($"{spacesString}Name = {dataDictionary.GetValue(NameKey)}");
            }
            sb.AppendLine($"{spacesString}{nameof(TypeKey)} = {TypeKey}");
            if (dataDictionary != null && TypeKey > 0)
            {
                sb.AppendLine($"{spacesString}TypeName = {dataDictionary.GetValue(TypeKey)}");
            }
            sb.AppendLine($"{spacesString}End ParamOfUserDefinedFunction");
            return sb.ToString();
        }
    }
}
