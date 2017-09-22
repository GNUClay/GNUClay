using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
    public class ScriptCommand : IToStringData
    {
        public OperationCode OperationCode = OperationCode.Nop;
        public ScriptCommand Next { get; set; }

        public int Position { get; set; }
        public ulong Key { get; set; }
        public object Value { get; set; }
        public ScriptCommand JumpToMe { get; set; }

#if DEBUG
        public string ToDbgString()
        {
            switch (OperationCode)
            {
                case OperationCode.Nop:
                case OperationCode.ClearStack:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.PushConst:
                    return $"[{Position}]{OperationCode}: {Key} {Value}";

                case OperationCode.PushEntity:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.PushProp:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.PushVar:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.CallUnOp:
                case OperationCode.CallBinOp:
                case OperationCode.CallWTargetN:
                case OperationCode.CallWTarget:
                case OperationCode.CallN:
                case OperationCode.Call:
                case OperationCode.CallAsyncWTargetN:
                case OperationCode.CallAsyncWTarget:
                case OperationCode.CallAsyncN:
                case OperationCode.CallAsync:
                case OperationCode.CallMWTargetN:
                case OperationCode.CallMWTarget:
                case OperationCode.CallMN:
                case OperationCode.CallM:
                case OperationCode.CallMAsyncWTargetN:
                case OperationCode.CallMAsyncWTarget:
                case OperationCode.CallMAsyncN:
                case OperationCode.CallMAsync:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.JumpIfTrue:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.JumpIfFalse:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.Jump:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.Return:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.ReturnValue:
                    return $"[{Position}]{OperationCode}";

                default: throw new ArgumentOutOfRangeException(nameof(OperationCode), OperationCode, null);
            }
        }
#endif

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine($"{nameof(Position)} = {Position}");
            tmpSb.AppendLine($"{nameof(OperationCode)} = {OperationCode}");
            tmpSb.AppendLine($"{nameof(Key)} = {Key}");
            tmpSb.AppendLine($"{nameof(Value)} = {Value}");
            return tmpSb.ToString();
        }
    }
}
