using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Expressions
{
    public class ASTVarExpression: ASTExpression
    {
        public ASTVarExpression()
            : base(ExpressionKind.VarExpression)
        {
        }

        public ulong TypeKey { get; set; }
        public bool IsSystem { get; set; }

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
            sb.AppendLine($"{spacesString}Begin VarExpression");
            sb.AppendLine($"{spacesString}{nameof(TypeKey)} = {TypeKey}");
            if (dataDictionary != null)
            {
                sb.AppendLine($"{spacesString}TypeName = {dataDictionary.GetValue(TypeKey)}");
            }
            sb.AppendLine($"{spacesString}{nameof(IsSystem)} = {IsSystem}");
            sb.AppendLine($"{spacesString}End VarExpression");
            return sb.ToString();
        }
    }
}
