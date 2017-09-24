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

                    case StatementKind.If:
                        {
                            var leaf = new IfStatementLeaf(Context);
                            leaf.Run(statement as ASTIfStatement);
                            AddCommands(leaf.Result);
                        }          
                        break;

                    case StatementKind.While:
                        {
                            var expression = statement as ASTWhileStatement;

                            if(expression.WithPrecondition)
                            {
                                var leaf = new PreconditionWhileStatementLeaf(Context);
                                leaf.Run(expression);
                                AddCommands(leaf.Result);
                                break;
                            }
                            throw new NotImplementedException();
                        }

                    case StatementKind.Return:
                        {
                            var leaf = new ReturnStatementLeaf(Context);
                            leaf.Run(statement as ASTReturnStatement);
                            AddCommands(leaf.Result);
                            break;
                        }

                    default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
                }
            }

#if DEBUG
            ShowCommands();
#endif
        }
    }
}
