using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class ExpressionStatementLeaf : BaseLeaf
    {
        public ExpressionStatementLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTExpressionStatement ast)
        {
            var expression = ast.Expression;

            var leaf = new ExpressionNodeLeaf(Context);
            leaf.Run(expression);

            AddCommands(leaf.Result);

            AddCommand(new ScriptCommand()
            {
                OperationCode = OperationCode.ClearStack
            });
        }
    }
}
