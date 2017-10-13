using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary>
    /// Represents signature of the function.
    /// </summary>
    public class ExternalCommandFilter: IExternalCommandFilter
    {
        /// <summary>
        /// Gets or sets the key of the function.
        /// </summary>
        public ulong FunctionKey { get; set; }

        /// <summary>
        /// Gets or sets the target of the function.
        /// </summary>
        public ulong TargetKey { get; set; }

        /// <summary>
        /// Gets or sets the holder of the function.
        /// </summary>
        public ulong HolderKey { get; set; }

        /// <summary>
        /// Gets or sets definitions of parameters of the function.
        /// </summary>
        public Dictionary<ulong, IExternalCommandFilterParam> Params { get; set; } = new Dictionary<ulong, IExternalCommandFilterParam>();

        /// <summary>
        /// Gets or sets the handler of the function.
        /// </summary>
        public ExternalCommandHandler Handler { get; set; }

        /// <summary>
        /// Serves as the hash function that has size as ulong.
        /// </summary>
        /// <returns>Return value of the hash.</returns>
        public ulong GetLongHashCode()
        {
            var result = FunctionKey ^ TargetKey ^ HolderKey;

            foreach (var item in Params)
            {
                result ^= item.Value.GetLongHashCode();
            }

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
            var nextIndent = indent + 4;
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine($"{spacesString}Begin ExternalCommandFilter");
            tmpSb.AppendLine($"{spacesString}{nameof(FunctionKey)} = {FunctionKey}");
            if (dataDictionary != null && FunctionKey > 0)
            {
                tmpSb.AppendLine($"{spacesString}FunctionName = {dataDictionary.GetValue(FunctionKey)}");
            }
            tmpSb.AppendLine($"{spacesString}{nameof(TargetKey)} = {TargetKey}");
            if (dataDictionary != null && TargetKey > 0)
            {
                tmpSb.AppendLine($"{spacesString}TargetName = {dataDictionary.GetValue(TargetKey)}");
            }
            tmpSb.AppendLine($"{spacesString}{nameof(HolderKey)} = {HolderKey}");
            if (dataDictionary != null && HolderKey > 0)
            {
                tmpSb.AppendLine($"{spacesString}HolderName = {dataDictionary.GetValue(HolderKey)}");
            }

            if(Params == null)
            {
                tmpSb.AppendLine($"{spacesString}{nameof(Params)} = null");
            }
            else
            {
                tmpSb.AppendLine($"{spacesString}Begin {nameof(Params)}");

                var paramSpacesString = _ObjectHelper.CreateSpaces(nextIndent);
                foreach (var paramItem in Params)
                {
                    var paramKey = paramItem.Key;

                    tmpSb.AppendLine($"{paramSpacesString}{nameof(paramKey)} = {paramKey}");
                    if (dataDictionary != null && FunctionKey > 0)
                    {
                        tmpSb.AppendLine($"{spacesString}ParamName = {dataDictionary.GetValue(paramKey)}");
                    }
                    tmpSb.AppendLine(paramItem.Value?.ToString(dataDictionary, nextIndent));
                }

                tmpSb.AppendLine($"{spacesString}End {nameof(Params)}");
            }
            tmpSb.AppendLine($"{spacesString}End ExternalCommandFilter");
            return tmpSb.ToString();
        }
    }
}
