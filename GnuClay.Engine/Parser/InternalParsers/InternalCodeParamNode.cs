using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalCodeParamNode
    {
        public bool IsNamed { get; set; }
        public InternalCodeExpressionNode Name { get; set; }
        public InternalCodeExpressionNode Value { get; set; }

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
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine($"{spacesString}Begin InternalCodeParamNode");
            tmpSb.AppendLine($"{spacesString}{nameof(IsNamed)} = {IsNamed}");

            if (Name == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Name)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Name)} =");
                tmpSb.AppendLine(Name.ToString(dataDictionary, nextIndent));
            }

            if (Value == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Value)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Value)} =");
                tmpSb.AppendLine(Value.ToString(dataDictionary, nextIndent));
            }

            tmpSb.AppendLine($"{spacesString}End InternalCodeParamNode");
            return tmpSb.ToString();
        }
    }
}
