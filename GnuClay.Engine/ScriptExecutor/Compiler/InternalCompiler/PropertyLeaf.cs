using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class PropertyLeaf : BaseLeaf
    {
        public PropertyLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTBinaryOperator ast)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }
    }
}
