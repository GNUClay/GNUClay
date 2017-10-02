using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.ExternalData
{
    public class ExternalParamInfo : IExternalParamInfo
    {
        public IExternalValue ParamName { get; set; }
        public IExternalValue ParamValue { get; set; }

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
            tmpSb.AppendLine($"{spacesString}Begin ExternalEntityAction");
            if (ParamName == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(ParamName)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(ParamName)} =");
                tmpSb.AppendLine(ParamName.ToString(dataDictionary, nextIndent));
            }
            if (ParamValue == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(ParamValue)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(ParamValue)} =");
                tmpSb.AppendLine(ParamValue.ToString(dataDictionary, nextIndent));
            }
            tmpSb.AppendLine($"{spacesString}End ExternalEntityAction");
            return tmpSb.ToString();
        }
    }
}
