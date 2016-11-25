using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Statements
{
    public enum StatementKind
    {
        Undefined,
        Expression
    }

    public abstract class ASTStatement
    {
        protected ASTStatement(StatementKind kind)
        {
            Kind = kind;
        }

        public StatementKind Kind { get; private set; } = StatementKind.Undefined;
    }
}
