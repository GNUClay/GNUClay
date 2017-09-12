using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Statements
{
    public class ASTWhileStatement : ASTStatement
    {
        public ASTWhileStatement()
            : base(StatementKind.While)
        {
        }

        public ASTExpression Condition { get; set; }
        public ASTCodeBlock Body { get; set; }
        public bool WithPrecondition { get; set; }

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
            sb.AppendLine($"{spacesString}Begin WhileStatement");
            sb.AppendLine($"{spacesString}{nameof(WithPrecondition)} = {WithPrecondition}");
            if (Condition == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Condition)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(Condition)} = ");
                sb.AppendLine(Condition.ToString(dataDictionary, nextIndent));
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
            sb.AppendLine($"{spacesString}End WhileStatement");
            return sb.ToString();
        }
    }
}
