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

                case OperationCode.OldBeginCall:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.OldBeginCallMethod:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.OldBeginCallMethodOfPrevEntity:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.OldSetTarget:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.OldSetParamName:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.OldSetParamVal:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.CallUnOp:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.CallBinOp:
                    return $"[{Position}]{OperationCode}: {Key}";

                case OperationCode.OldCall:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.OldCallByPos:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.OldCallAsync:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.OldCallAsyncByPos:
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
