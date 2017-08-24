using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class ScriptCommand : IToStringData
    {
        public OperationCode OperationCode = OperationCode.Nop;
        public ScriptCommand Next = null;

        public int Position = 0;
        public ulong Key = 0;
        public object Value = null;
        
#if DEBUG
        public string ToDbgString()
        {
            switch (OperationCode)
            {
                case OperationCode.Nop:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.PushConst:
                    return $"[{Position}]{OperationCode}: {Key} {Value}";

                case OperationCode.PushEntity:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.PushProp:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.PushVar:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.BeginCall:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.BeginCallMethod:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.BeginCallMethodOfPrevEntity:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.SetTarget:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.SetParamName:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.SetParamVal:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.CallUnOp:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.CallBinOp:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.Call:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.CallByPos:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.CallAsync:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.CallAsyncByPos:
                    return $"[{Position}]{OperationCode}";

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
