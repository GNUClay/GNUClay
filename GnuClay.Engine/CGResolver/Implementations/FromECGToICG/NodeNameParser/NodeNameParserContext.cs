using GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser
{
    public class NodeNameParserContext
    {
        public NodeNameParserContext(List<NodeNameToken> tokens)
        {
            mBuffer = new Queue<NodeNameToken>(tokens);
        }

        private Queue<NodeNameToken> mBuffer = null;

        public NodeNameToken GetToken()
        {
            if (mBuffer.Count == 0)
            {
                return null;
            }

            return mBuffer.Dequeue();
        }

        public void Recovery(NodeNameToken token)
        {
            var tmpNewList = new List<NodeNameToken>() { token };

            if (mBuffer.Count > 0)
            {
                tmpNewList.AddRange(mBuffer.ToList());
            }

            mBuffer = new Queue<NodeNameToken>(tmpNewList);
        }

        private NodeNameInfo mResult = new NodeNameInfo();

        public NodeNameInfo Result
        {
            get
            {
                return mResult;
            }
        }
    }
}
