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
        public CodeBlockLeaf(CompilerContext context)
            : base(context)
        {
        }

        private ASTCodeBlock mASTCodeBlock = null;

        public void Run(ASTCodeBlock ast)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            mASTCodeBlock = ast;

            foreach(var statement in mASTCodeBlock.Statements)
            {
                switch(statement.Kind)
                {
                    case StatementKind.Expression:
                        var tmpExpressionLeaf = new ExpressionLeaf(Context);
                        tmpExpressionLeaf.Run(statement as ASTExpressionStatement);
                        break;
                        
                    default: throw new NotSupportedException($"`{statement.Kind}` is not supported.");
                }
            }
        }
    }
}
