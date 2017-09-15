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
        public ASTCodeBlock CodeBlock { get; set; }

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
            if(dataDictionary != null)
            {
                sb.AppendLine($"{spacesString}FunctionName = {dataDictionary.GetValue(FunctionKey)}");
            }
            sb.AppendLine($"{spacesString}{nameof(TargetKey)} = {TargetKey}");
            if (dataDictionary != null)
            {
                sb.AppendLine($"{spacesString}TargetName = {dataDictionary.GetValue(TargetKey)}");
            }
            sb.AppendLine($"{spacesString}{nameof(HolderKey)} = {HolderKey}");
            if (dataDictionary != null)
            {
                sb.AppendLine($"{spacesString}HolderName = {dataDictionary.GetValue(HolderKey)}");
            }
            if (CodeBlock == null)
            {
                sb.AppendLine($"{spacesString}{nameof(CodeBlock)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(CodeBlock)} = ");
                sb.AppendLine(CodeBlock.ToString(dataDictionary, nextIndent));
            }
            sb.AppendLine($"{spacesString}End UserDefinedFunction");
            return sb.ToString();
        }
    }
}
