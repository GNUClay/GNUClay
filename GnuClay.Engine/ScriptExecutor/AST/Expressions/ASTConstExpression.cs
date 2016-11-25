using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Expressions
{
    public class ASTConstExpression : ASTExpression
    {
        public ASTConstExpression()
            : base(ExpressionKind.ConstExpression)
        {
        }

        public int TypeKey { get; set; }
        public object Value { get; set; }
    }
}
