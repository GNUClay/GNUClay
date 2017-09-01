using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Expressions
{
    public class ASTBinaryOperator: ASTExpression
    {
        public ASTBinaryOperator()
            : base (ExpressionKind.BinaryOperator)
        {
        }

        public ulong OperatorKey { get; set; }
        public ASTExpression Left { get; set; }
        public ASTExpression Right { get; set; }

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
            sb.AppendLine($"{spacesString}Begin BinaryOperator");
            sb.AppendLine($"{spacesString}{nameof(OperatorKey)} = {OperatorKey}");
            if(dataDictionary != null)
            {
                sb.AppendLine($"{spacesString}OperatorName = {dataDictionary.GetValue(OperatorKey)}");
            }

            if (Left == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Left)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(Left)} =");
                sb.AppendLine(Left.ToString(dataDictionary, nextIndent));
            }

            if (Right == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Right)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(Right)} =");
                sb.AppendLine(Right.ToString(dataDictionary, nextIndent));
            }
                     
            sb.AppendLine($"{spacesString}End BinaryOperator");
            return sb.ToString();
        }
    }
}
