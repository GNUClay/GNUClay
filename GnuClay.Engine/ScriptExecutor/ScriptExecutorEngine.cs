using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.Parser.CommonData;
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
        }

        public override void FirstInit()
        {
            mCompiler = Context.ScriptCompiler;
            mFunctionsEngine = Context.FunctionsEngine;
        }

        private GnuClayScriptCompiler mCompiler = null;
        private FunctionsEngine mFunctionsEngine = null;

        public void Execute(ASTCodeBlock codeBlock)
        {
            var tmpCodeFrame = mCompiler.Compile(codeBlock);
            mFunctionsEngine.CallCodeFrame(tmpCodeFrame);
        }

        public void DefineFunction(UserDefinedFunction userDefinedFunction)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"DefineFunction userDefinedFunction = {userDefinedFunction.ToString(Context.DataDictionary, 0)}");
#endif
            var tmpCodeFrame = mCompiler.Compile(userDefinedFunction.Body);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"DefineFunction tmpCodeFrame = {tmpCodeFrame?.ToString(Context.DataDictionary, 0)}");
#endif


            throw new NotImplementedException();
        }
    }
}
