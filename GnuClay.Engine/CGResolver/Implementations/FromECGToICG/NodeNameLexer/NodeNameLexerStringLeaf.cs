using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public class NodeNameLexerStringLeaf: NodeNameLexerBaseLeaf
    {
        public NodeNameLexerStringLeaf(NodeNameLexerContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }
    }
}
