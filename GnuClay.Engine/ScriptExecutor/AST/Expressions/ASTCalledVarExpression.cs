using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Expressions
{
    public class ASTCalledVarExpression : ASTExpression
    {
        public ASTCalledVarExpression()
             : base(ExpressionKind.CalledVarExpression)
        {
        }

        public ulong TypeKey { get; set; }
        public bool IsAsync = false;
        public ASTExpression Target { get; set; }
        public List<ASTExpression> Params { get; set; } = new List<ASTExpression>();

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var nextIndent = indent + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spacesString}Begin CalledVarExpression");
            sb.AppendLine($"{spacesString}{nameof(TypeKey)} = {TypeKey}");
            if (dataDictionary != null)
            {
                sb.AppendLine($"{spacesString}TypeName = {dataDictionary.GetValue(TypeKey)}");
            }
            sb.AppendLine($"{spacesString}{nameof(IsAsync)} = {IsAsync}");
            if (Target == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Target)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(Target)} =");
                sb.AppendLine(Target.ToString(dataDictionary, nextIndent));
            }
            sb.AppendLine($"{spacesString}Begin Params");
            foreach (var paramItem in Params)
            {
                sb.AppendLine(paramItem.ToString(dataDictionary, nextIndent));
            }
            sb.AppendLine($"{spacesString}End Params");
            sb.AppendLine($"{spacesString}End CalledVarExpression");
            return sb.ToString();
        }
    }
}
