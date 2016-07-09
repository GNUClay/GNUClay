using GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser
{
    public class NodeNameParserEngine
    {
        public NodeNameInfo Run(List<NodeNameToken> tokens)
        {
            var tmpContext = new NodeNameParserContext(tokens);

            var tmpLeaf = new NodeNameParserMainLeaf(tmpContext);

            tmpLeaf.Run();

            return tmpContext.Result;
        }
    }
}
