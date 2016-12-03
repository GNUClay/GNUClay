using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Statements
{
    public class ASTExpressionStatement: ASTStatement
    {
        public ASTExpressionStatement()
            : base(StatementKind.Expression)
        {
        }

        public ASTExpression Expression { get; set; }
    }
}
