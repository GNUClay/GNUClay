using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public abstract class NodeNameLexerBaseLeaf
    {
        protected NodeNameLexerBaseLeaf(NodeNameLexerContext context)
        {
            mContext = context;
        }

        private NodeNameLexerContext mContext = null;

        protected NodeNameLexerContext Context
        {
            get
            {
                return mContext;
            }
        }
    }
}
