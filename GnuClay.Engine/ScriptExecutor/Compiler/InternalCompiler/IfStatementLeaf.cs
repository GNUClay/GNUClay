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
            ASTNode = ast;

            var conditionLeaf = new ExpressionNodeLeaf(Context);
            conditionLeaf.Run(ast.Condition);
            AddCommands(conditionLeaf.Result);
           
            if(ast.ElseBody == null)
            {
                ParseWithoutElse();
                return;
            }

            ParseWithElse();
        }

        private void ParseWithElse()
        {
            var nop_1 = new ScriptCommand();
            nop_1.OperationCode = OperationCode.Nop;

            var nop_2 = new ScriptCommand();
            nop_2.OperationCode = OperationCode.Nop;

            var nop_3 = new ScriptCommand();
            nop_3.OperationCode = OperationCode.Nop;

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

            command = new ScriptCommand();
            command.OperationCode = OperationCode.Jump;
            command.JumpToMe = nop_3;
            AddCommand(command);

            AddCommand(nop_2);

            var elseBodyLeaf = new CodeBlockLeaf(Context);
            elseBodyLeaf.Run(ASTNode.ElseBody);
            AddCommands(elseBodyLeaf.Result);

            AddCommand(nop_3);
        }

        private void ParseWithoutElse()
        {
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
        }
    }
}
