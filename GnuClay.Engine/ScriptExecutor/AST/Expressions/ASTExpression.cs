using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Expressions
{
    public enum ExpressionKind
    {
        Undefined,
        BinaryOperator,
        ConstExpression
    }

    public abstract class ASTExpression
    {
        protected ASTExpression(ExpressionKind kind)
        {
            Kind = kind;
        }

        public ExpressionKind Kind { get; private set; } = ExpressionKind.Undefined;
    }
}
