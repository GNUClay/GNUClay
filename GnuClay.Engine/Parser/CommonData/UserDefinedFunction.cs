using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.CommonData
{
    public class UserDefinedFunction
    {
        public ulong FunctionKey { get; set; }
        public ulong TargetKey { get; set; }
        public ulong HolderKey { get; set; }
        public List<ParamOfUserDefinedFunction> Params = new List<ParamOfUserDefinedFunction>();
        public ulong ReturnTypeKey { get; set; }
        public ASTCodeBlock Body { get; set; }

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
            sb.AppendLine($"{spacesString}Begin UserDefinedFunction");
            sb.AppendLine($"{spacesString}{nameof(FunctionKey)} = {FunctionKey}");
            if(dataDictionary != null && FunctionKey > 0)
            {
                sb.AppendLine($"{spacesString}FunctionName = {dataDictionary.GetValue(FunctionKey)}");
            }
            sb.AppendLine($"{spacesString}{nameof(TargetKey)} = {TargetKey}");
            if (dataDictionary != null && TargetKey > 0)
            {
                sb.AppendLine($"{spacesString}TargetName = {dataDictionary.GetValue(TargetKey)}");
            }
            sb.AppendLine($"{spacesString}{nameof(HolderKey)} = {HolderKey}");
            if (dataDictionary != null && HolderKey > 0)
            {
                sb.AppendLine($"{spacesString}HolderName = {dataDictionary.GetValue(HolderKey)}");
            }
            sb.AppendLine($"{spacesString}{nameof(HolderKey)} = {HolderKey}");
            if (dataDictionary != null && ReturnTypeKey > 0)
            {
                sb.AppendLine($"{spacesString}ReturnTypeName = {dataDictionary.GetValue(ReturnTypeKey)}");
            }
            if (Params == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Params)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}Begin Params");
                foreach (var paramItem in Params)
                {
                    sb.AppendLine(paramItem.ToString(dataDictionary, nextIndent));
                }
                sb.AppendLine($"{spacesString}End Params");
            }
            if (Body == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Body)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(Body)} = ");
                sb.AppendLine(Body.ToString(dataDictionary, nextIndent));
            }
            sb.AppendLine($"{spacesString}End UserDefinedFunction");
            return sb.ToString();
        }
    }
}
