using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    [Serializable]
    public class ScriptCommand : ISmartToString
    {
        public OperationCode OperationCode = OperationCode.Nop;
        public ScriptCommand Next { get; set; }

        public int Position { get; set; }
        public ulong Key { get; set; }
        public object Value { get; set; }
        public ScriptCommand JumpToMe { get; set; }

        public string ToShortString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);

            switch (OperationCode)
            {
                case OperationCode.Nop:
                case OperationCode.ClearStack:
                    return $"[{Position}]{OperationCode}";

                case OperationCode.PushConst:
                    {
                        var sb = new StringBuilder();
                        sb.Append($"[{Position}]{OperationCode}: {Key}");
                        if(dataDictionary != null)
                        {
                            sb.Append($"({dataDictionary.GetValue(Key)})");
                        }
                        
                        sb.Append($" {Value}");
                        return sb.ToString();
                    }
                    
                case OperationCode.PushEntity:
                    {
                        var sb = new StringBuilder();
                        sb.Append($"[{Position}]{OperationCode}: {Key}");
                        if (dataDictionary != null)
                        {
                            sb.Append($"({dataDictionary.GetValue(Key)})");
                        }
                        return sb.ToString();
                    }

                case OperationCode.PushProp:
                    {
                        var sb = new StringBuilder();
                        sb.Append($"[{Position}]{OperationCode}: {Key}");
                        if (dataDictionary != null)
                        {
                            sb.Append($"({dataDictionary.GetValue(Key)})");
                        }
                        return sb.ToString();
                    }

                case OperationCode.PushVar:
                case OperationCode.PushSystemVar:
                    {
                        var sb = new StringBuilder();
                        sb.Append($"[{Position}]{OperationCode}: {Key}");
                        if (dataDictionary != null)
                        {
                            sb.Append($"({dataDictionary.GetValue(Key)})");
                        }
                        return sb.ToString();
                    }

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
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine($"{spacesString}Begin ScriptCommand");
            tmpSb.AppendLine($"{spacesString}{nameof(Position)} = {Position}");
            tmpSb.AppendLine($"{spacesString}{nameof(OperationCode)} = {OperationCode}");
            tmpSb.AppendLine($"{spacesString}{nameof(Key)} = {Key}");
            if(dataDictionary != null)
            {
                switch (OperationCode)
                {
                    case OperationCode.PushConst:
                    case OperationCode.PushEntity:
                    case OperationCode.PushProp:
                    case OperationCode.PushVar:
                        tmpSb.AppendLine($"{spacesString}TypeName = {dataDictionary.GetValue(Key)}");
                        break;
                }
            }

            tmpSb.AppendLine($"{spacesString}{nameof(Value)} = {Value}");
            tmpSb.AppendLine($"{spacesString}End ScriptCommand");
            return tmpSb.ToString();
        }
    }
}
