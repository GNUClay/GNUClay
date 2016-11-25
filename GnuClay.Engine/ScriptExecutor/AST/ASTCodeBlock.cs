using GnuClay.Engine.ScriptExecutor.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST
{
    public class ASTCodeBlock
    {
        public List<ASTStatement> Statements { get; set; } = new List<ASTStatement>();
    }
}
