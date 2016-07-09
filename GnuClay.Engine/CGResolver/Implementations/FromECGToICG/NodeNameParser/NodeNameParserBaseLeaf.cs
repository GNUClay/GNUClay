using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser
{
    public abstract class NodeNameParserBaseLeaf
    {
        protected NodeNameParserBaseLeaf(NodeNameParserContext context)
        {
            mContext = context;
        }

        private NodeNameParserContext mContext = null;

        protected NodeNameParserContext Context
        {
            get
            {
                return mContext;
            }
        }
    }
}
