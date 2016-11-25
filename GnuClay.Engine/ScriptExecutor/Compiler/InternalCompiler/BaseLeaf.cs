using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public abstract class BaseLeaf
    {
        protected BaseLeaf(CompilerContext context)
        {
            Context = context;
        }

        protected CompilerContext Context { get; set; }
    }
}
