using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class ReturnStatementLeaf : BaseLeaf
    {
        public ReturnStatementLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTReturnStatement ast)
        {
            var expression = ast.Expression;

            if(expression == null)
            {
                var command_1 = new ScriptCommand();
                command_1.OperationCode = OperationCode.Return;
                AddCommand(command_1);

                return;
            }

            var expressionLeaf = new ExpressionNodeLeaf(Context);
            expressionLeaf.Run(expression);
            AddCommands(expressionLeaf.Result);

            var command = new ScriptCommand();
            command.OperationCode = OperationCode.ReturnValue;
            AddCommand(command);
        }
    }
}
