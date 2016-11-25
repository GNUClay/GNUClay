using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class CompilerContext
    {
        public FunctionModel Result { get; set; } = new FunctionModel();
        public GnuClayEngineComponentContext MainContext { get; set; }
    }
}
