using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.Compiler;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class ScriptExecutorEngine: BaseGnuClayEngineComponent
    {
        public ScriptExecutorEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mCompiler = new GnuClayScriptCompiler(context);
        }

        private GnuClayScriptCompiler mCompiler = null;

        public GnuClayScriptCompiler Compiler
        {
            get
            {
                return mCompiler;
            }
        }

        public void Execute(ASTCodeBlock codeBlock)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Execute");

            throw new NotImplementedException();

            //var tmpCodeFrame = mCompiler.Compile(codeBlock);
            //var context = new GnuClayThreadExecutionContext();
            //context.MainContext = Context;

            //var tmpInternalThreadExecutor = new InternalThreadExecutor(tmpCodeFrame, context);

            //tmpInternalThreadExecutor.Run();
        }
    }
}
