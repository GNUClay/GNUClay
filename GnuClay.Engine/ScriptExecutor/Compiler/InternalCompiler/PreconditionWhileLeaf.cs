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
    public class PreconditionWhileLeaf : BaseLeaf
    {
        public PreconditionWhileLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTWhileStatement ast)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif

            var nop_0 = new ScriptCommand();
            nop_0.OperationCode = OperationCode.Nop;

            AddCommand(nop_0);

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

            var bodyLeaf = new CodeBlockLeaf(Context);
            bodyLeaf.Run(ast.Body);
            AddCommands(bodyLeaf.Result);

            command = new ScriptCommand();
            command.OperationCode = OperationCode.Jump;
            command.JumpToMe = nop_0;
            AddCommand(command);

            AddCommand(nop_2);

#if DEBUG
            ShowCommands();
#endif
        }
    }
}
