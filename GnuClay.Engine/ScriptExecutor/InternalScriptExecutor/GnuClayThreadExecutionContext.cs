using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    [Serializable]
    public class GnuClayThreadExecutionContext
    {
        public ContextOfVariables ContextOfVariables = null;
        public ContextOfSystemVariables ContextOfSystemVariables = null;
    }
}
