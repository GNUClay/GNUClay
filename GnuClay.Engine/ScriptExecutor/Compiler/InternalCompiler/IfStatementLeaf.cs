using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class IfStatementLeaf : BaseLeaf
    {
        public IfStatementLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private ASTIfStatement ASTNode;

        public void Run(ASTIfStatement ast)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif

            ASTNode = ast;

            var conditionLeaf = new ExpressionNodeLeaf(Context);
            conditionLeaf.Run(ast.Condition);
            AddCommands(conditionLeaf.Result);

#if DEBUG
            ShowCommands();
#endif
             
            if(ast.ElseBody == null)
            {
                ParseWithoutElse();
                return;
            }

            ParseWithElse();
        }

        private void ParseWithElse()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("");
#endif

            throw new NotImplementedException();
        }

        private void ParseWithoutElse()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("");
#endif

            var nop_1 = new ScriptCommand();
            nop_1.OperationCode = OperationCode.Nop;

            var nop_2 = new ScriptCommand();
            nop_2.OperationCode = OperationCode.Nop;

            var command = new ScriptCommand();
            command.OperationCode = OperationCode.JumpIfTrue;
            command.JumpToMe = nop_1;
            AddCommand(command);

            command = new ScriptCommand();
            command.OperationCode = OperationCode.Jump;
            command.JumpToMe = nop_2;
            AddCommand(command);

            AddCommand(nop_1);

            var ifLeaf = new CodeBlockLeaf(Context);
            ifLeaf.Run(ASTNode.Body);
            AddCommands(ifLeaf.Result);

            AddCommand(nop_2);

#if DEBUG
            ShowCommands();
#endif
        }
    }
}
