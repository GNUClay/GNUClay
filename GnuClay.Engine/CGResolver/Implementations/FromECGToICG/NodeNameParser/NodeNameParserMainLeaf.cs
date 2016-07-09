using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser
{
    public class NodeNameParserMainLeaf: NodeNameParserBaseLeaf
    {
        public NodeNameParserMainLeaf(NodeNameParserContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }
    }
}
