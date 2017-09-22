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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif
            var expression = ast.Expression;

            var leaf = new ExpressionNodeLeaf(Context);
            leaf.Run(expression);

            AddCommands(leaf.Result);

            AddCommand(new ScriptCommand()
            {
                OperationCode = OperationCode.ClearStack
            });
        }

        //private void ProcessBinaryOperator(ASTBinaryOperator expression)
        //{
        //    ProcessNode(expression.Left);
        //    ProcessNode(expression.Right);

        //    AddCommand(new ScriptCommand()
        //    {
        //        OperationCode = OperationCode.CallBinOp,
        //        Key = expression.OperatorKey
        //    });
        //}

        //private void ProcessConstExpression(ASTConstExpression expression)
        //{
        //    var tmpCommand = new ScriptCommand();
        //    tmpCommand.OperationCode = OperationCode.PushConst;
        //    tmpCommand.Key = expression.TypeKey;
        //    tmpCommand.Value = expression.Value;

        //    AddCommand(tmpCommand);
        //}
    }
}
