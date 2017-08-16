using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class Command : ILongHashableObject
    {
        public GnuClayThreadExecutionContext ExecutionContext { get; set; }
        public IValue Function { get; set; }
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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetParam key = {key} this = {this}");
#endif

            return NamedParamsDict[key];
        }

        public IValue GetParamValue(ulong key)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetParamValue key = {key}");
#endif

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
            var sb = new StringBuilder();

            sb.AppendLine($"{nameof(ExecutionContext)} = {ExecutionContext}");
            sb.AppendLine($"{nameof(Function)} = {Function}");
            sb.AppendLine($"{nameof(Holder)} = {Holder}");
            sb.AppendLine($"{nameof(TargetKey)} = {TargetKey}");
            sb.AppendLine($"{nameof(PositionedParams)} = {_ListHelper._ToString(PositionedParams)}");
            sb.AppendLine($"{nameof(NamedParams)} = {_ListHelper._ToString(NamedParams)}");
            sb.AppendLine($"{nameof(IsCallByNamedParams)} = {IsCallByNamedParams}");

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
