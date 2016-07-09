using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public class NodeNameLexerMainLeaf: NodeNameLexerBaseLeaf
    {
        public NodeNameLexerMainLeaf(NodeNameLexerContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }
    }
}
