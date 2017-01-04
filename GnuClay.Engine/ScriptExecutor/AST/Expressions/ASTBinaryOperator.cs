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
    }
}
