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

        public ulong Key = 0;
        public int ArgsCount = 0;

        public ScriptCommand Next = null;

        public object Value = null;

        public string ToDbgString()
        {
            switch (OperationCode)
            {
                case OperationCode.Nop:
                    return OperationCode.ToString();

                case OperationCode.PushConst:
                    return $"{OperationCode}: {Key} {Value}";

                case OperationCode.CallBinOp:
                    return $"{OperationCode}: {Key}";

                case OperationCode.Call:
                    return $"{OperationCode}: {Key}";

                //case OperationCode.PushEntity:
                //    return $"{OperationCode}: {Key}";

                //case OperationCode.SetProp:
                //    return $"{OperationCode}: {Key}";

                default: throw new ArgumentOutOfRangeException(nameof(OperationCode), $"Unknown OperationCode `{OperationCode}`.");
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
