using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    [Serializable]
    public class Command : ILongHashableObject, ISmartToString
    {
        public GnuClayThreadExecutionContext ExecutionContext { get; set; }
        public IValue Function { get; set; }
        public ulong DescriptorOfFunction { get; set; }
        public IValue Holder { get; set; }
        public ulong TargetKey { get; set; }
        public List<PositionParamInfo> PositionedParams { get; set; }
        public List<NamedParamInfo> NamedParams { get; set; }
        public bool IsCallByNamedParams { get; set; }
        public Dictionary<ulong, IValue> NamedParamsDict { get; set; }
        public void CreateParamsDict()
        {
            if(NamedParamsDict == null)
            {
                NamedParamsDict = new Dictionary<ulong, IValue>();
            }
            else
            {
                NamedParamsDict.Clear();
            }

            NamedParamsDict = NamedParams.ToDictionary(p => p.ParamName.TypeKey, p => p.ParamValue);
        }

        public IValue GetParam(ulong key)
        {
            return NamedParamsDict[key];
        }

        public IValue GetParamValue(ulong key)
        {
            var value = NamedParamsDict[key];

            if(value.IsValueContainer)
            {
                return value.ValueFromContainer;
            }

            return value;
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
            var sb = new StringBuilder();
            sb.AppendLine($"{spacesString}Begin Command");
            sb.AppendLine($"{spacesString}{nameof(ExecutionContext)} = {ExecutionContext}");
            sb.AppendLine($"{spacesString}{nameof(Function)} = {Function?.ToString(dataDictionary, nextIndent)}");
            sb.AppendLine($"{nameof(DescriptorOfFunction)} = {DescriptorOfFunction}");
            sb.AppendLine($"{spacesString}{nameof(Holder)} = {Holder?.ToString(dataDictionary, nextIndent)}");
            sb.AppendLine($"{spacesString}{nameof(TargetKey)} = {TargetKey}");
            sb.AppendLine($"{spacesString}{nameof(PositionedParams)} = {_ListHelper._ToString(PositionedParams)}");
            sb.AppendLine($"{spacesString}{nameof(NamedParams)} = {_ListHelper._ToString(NamedParams)}");
            sb.AppendLine($"{spacesString}{nameof(IsCallByNamedParams)} = {IsCallByNamedParams}");
            sb.AppendLine($"{spacesString}{spacesString}End Command");

            return sb.ToString();
        }

        public ulong GetLongHashCode()
        {
            ulong result = 0;

            if (Function != null)
            {
                result ^= Function.GetLongHashCode();

                if(result < 100000)
                {
                    result *= 1000;
                }
            }

            if (Holder != null)
            {
                result ^= Holder.GetLongHashCode();
            }

            result ^= TargetKey;

            if (PositionedParams != null)
            {
                foreach (var paramItem in PositionedParams)
                {
                    result ^= paramItem.GetLongHashCode();
                }
            }

            if (NamedParams != null)
            {
                foreach (var paramItem in NamedParams)
                {
                    result ^= paramItem.GetLongHashCode();
                }
            }

            return result;
        }
    }
}
