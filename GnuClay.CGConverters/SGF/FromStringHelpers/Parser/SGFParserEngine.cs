using GnuClay.CG;
using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class SGFParserEngine
    {
        public SGFParserEngine(ISGFNodeFactory nodeFactory)
        {
            mNodeFactory = nodeFactory;
        }

        private ISGFNodeFactory mNodeFactory = null;

        public IConceptualNode Run(List<SGFToken> tokens)
        {
            var tmpContext = new SGFParserContext(tokens, mNodeFactory);

            var tmpLeaf = new MainSGFParserLeaf(tmpContext);

            tmpLeaf.Run();

            return tmpLeaf.Result;
        }
    }
}
