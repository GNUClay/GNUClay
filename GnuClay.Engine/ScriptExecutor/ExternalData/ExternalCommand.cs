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
    /// <summary>
    /// Represents the information for calling a function.
    /// </summary>
    public class ExternalCommand : IExternalCommand
    {
        /// <summary>
        /// Gets or sets information about called function.
        /// </summary>
        public IExternalValue Function { get; set; }

        /// <summary>
        /// Gets or sets descriptor of the called function.
        /// </summary>
        public ulong DescriptorOfFunction { get; set; }

        /// <summary>
        /// Gets or sets the holder subject of the called function.
        /// </summary>
        public IExternalValue Holder { get; set; }

        /// <summary>
        /// Gets or sets the key of type of target.
        /// </summary>
        public ulong TargetKey { get; set; }

        /// <summary>
        /// Gets or sets the list of all params.
        /// </summary>
        public List<IExternalParamInfo> Params { get; set; }
        public Dictionary<ulong, IExternalValue> NamedParamsDict { get; set; }

        /// <summary>
        /// Gets the value of the param by it key.
        /// </summary>
        /// <param name="key">The key that corresponds with name of the param.</param>
        /// <returns>The value of the param by it key.</returns>
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
