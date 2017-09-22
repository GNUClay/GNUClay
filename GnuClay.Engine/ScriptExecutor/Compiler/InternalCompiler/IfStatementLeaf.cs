using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using System;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class IfStatementLeaf : BaseLeaf
    {
        public IfStatementLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTIfStatement ast)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }
    }
}
