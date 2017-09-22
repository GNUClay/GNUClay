using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class CodeBlockLeaf: BaseLeaf
    {
        public CodeBlockLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private ASTCodeBlock mASTCodeBlock = null;

        public void Run(ASTCodeBlock ast)
        {
            mASTCodeBlock = ast;

            foreach(var statement in mASTCodeBlock.Statements)
            {
                var kind = statement.Kind;

                switch (kind)
                {
                    case StatementKind.Expression:
                        var tmpExpressionLeaf = new ExpressionStatementLeaf(Context);
                        tmpExpressionLeaf.Run(statement as ASTExpressionStatement);
                        AddCommands(tmpExpressionLeaf.Result);
                        break;
                        
                    default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
                }
            }

#if DEBUG
            ShowCommands();
#endif
        }
    }
}
