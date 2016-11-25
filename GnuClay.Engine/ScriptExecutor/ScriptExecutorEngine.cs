using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.Compiler;
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
            NLog.LogManager.GetCurrentClassLogger().Info("ScriptExecutorEngine");

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
    }
}
