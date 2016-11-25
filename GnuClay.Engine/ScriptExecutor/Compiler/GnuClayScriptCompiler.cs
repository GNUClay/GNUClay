using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler
{
    public class GnuClayScriptCompiler: BaseGnuClayEngineComponent
    {
        public GnuClayScriptCompiler(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GnuClayScriptCompiler");
        }

        public FunctionModel Compile(ASTCodeBlock ast)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Compile");

            var context = new CompilerContext();
            context.MainContext = Context;

            var codeBlock = new CodeBlockLeaf(context);
            codeBlock.Run(ast);

            return context.Result;
        }
    }
}
