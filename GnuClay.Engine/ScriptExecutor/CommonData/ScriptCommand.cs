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

        public ulong Key = 0;
        public object Value = null;

        public string ToDbgString()
        {
            switch (OperationCode)
            {
                case OperationCode.Nop:
                    return $"{OperationCode}";

                case OperationCode.PushConst:
                    return $"{OperationCode}: {Key} {Value}";

                case OperationCode.PushEntity:
                    return $"{OperationCode}: {Key}";

                case OperationCode.PushProp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.PushVar:
                    return $"{OperationCode}: {Key}";

                case OperationCode.PushValFromProp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.PushValFromVar:
                    return $"{OperationCode}: {Key}";

                case OperationCode.SetValToProp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.SetValToVar:
                    return $"{OperationCode}: {Key}";

                case OperationCode.BeginCall:
                    return $"{OperationCode}";

                case OperationCode.BeginCallMethod:
                    return $"{OperationCode}: {Key}";

                case OperationCode.BeginCallMethodOfPrevEntity:
                    return $"{OperationCode}: {Key}";

                case OperationCode.SetTarget:
                    return $"{OperationCode}";

                case OperationCode.SetParamName:
                    return $"{OperationCode}";

                case OperationCode.SetParamVal:
                    return $"{OperationCode}";

                case OperationCode.CallUnOp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.CallBinOp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.Call:
                    return $"{OperationCode}";

                case OperationCode.CallByPos:
                    return $"{OperationCode}";

                case OperationCode.JumpIfFalse:
                    return $"{OperationCode}: {Key}";

                case OperationCode.Jump:
                    return $"{OperationCode}: {Key}";

                default: throw new ArgumentOutOfRangeException(nameof(OperationCode), OperationCode, null);
            }
        }

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

            tmpSb.Append(nameof(OperationCode));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(OperationCode.ToString());

            tmpSb.Append(nameof(Key));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Key.ToString());

            tmpSb.Append(nameof(Value));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Value?.ToString());

            return tmpSb.ToString();
        }
    }
}
