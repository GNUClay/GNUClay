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
    public class ExternalCommand : IExternalCommand
    {
        public IExternalValue Function { get; set; }
        public ulong DescriptorOfFunction { get; set; }
        public IExternalValue Holder { get; set; }
        public ulong TargetKey { get; set; }
        public List<IExternalParamInfo> Params { get; set; }
        public Dictionary<ulong, IExternalValue> NamedParamsDict { get; set; }

        public IExternalValue GetParamValue(ulong key)
        {
            return NamedParamsDict[key];
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
            var nextIndent = indent + 4;
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine($"{spacesString}Begin ExternalCommandFilter");
            if (Function == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Function)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Function)} =");
                tmpSb.AppendLine(Function.ToString(dataDictionary, nextIndent));
            }
            tmpSb.AppendLine($"{spacesString}{nameof(DescriptorOfFunction)} = {DescriptorOfFunction}");
            if (Holder == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Holder)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Holder)} =");
                tmpSb.AppendLine(Holder.ToString(dataDictionary, nextIndent));
            }
            tmpSb.AppendLine($"{spacesString}{nameof(TargetKey)} = {TargetKey}");
            if (dataDictionary != null && TargetKey > 0)
            {
                tmpSb.AppendLine($"{spacesString}TargetName = {dataDictionary.GetValue(TargetKey)}");
            }
            if (Params == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Params)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}Begin {nameof(Params)}");

                foreach (var paramItem in Params)
                {
                    tmpSb.AppendLine(paramItem?.ToString(dataDictionary, nextIndent));
                }

                tmpSb.AppendLine($"{spacesString}End {nameof(Params)}");
            }
            tmpSb.AppendLine($"{spacesString}End ExternalCommandFilter");
            return tmpSb.ToString();
        }
    }
}
