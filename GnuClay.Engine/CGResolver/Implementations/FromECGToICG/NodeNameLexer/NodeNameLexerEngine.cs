using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public class NodeNameLexerEngine
    {
        public List<NodeNameToken> Run(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var tmpContext = new NodeNameLexerContext(text.ToList());

            var tmpMainLeaf = new NodeNameLexerMainLeaf(tmpContext);

            tmpMainLeaf.Run();

            return tmpContext.ResultList;
        }
    }
}
