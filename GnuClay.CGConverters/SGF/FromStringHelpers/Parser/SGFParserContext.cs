using GnuClay.CG;
using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class SGFParserContext
    {
        public SGFParserContext(List<SGFToken> tokens, ISGFNodeFactory nodeFactory)
        {
            mBuffer = new Queue<SGFToken>(tokens);

            mNodeFactory = nodeFactory;
        }

        private Queue<SGFToken> mBuffer = null;

        private ISGFNodeFactory mNodeFactory = null;

        public SGFToken GetToken()
        {
            if (mBuffer.Count == 0)
            {
                return null;
            }

            return mBuffer.Dequeue();
        }

        public void Recovery(SGFToken token)
        {
            var tmpNewList = new List<SGFToken>() { token };

            if (mBuffer.Count > 0)
            {
                tmpNewList.AddRange(mBuffer.ToList());
            }

            mBuffer = new Queue<SGFToken>(tmpNewList);
        }

        public ISGFNodeFactory NodeFactory
        {
            get
            {
                return mNodeFactory;
            }
        }

        private Dictionary<string, INode> mNodesDict = new Dictionary<string, INode>();

        public void RegNode(string identifier, INode node)
        {
            if(mNodesDict.ContainsKey(identifier))
            {
                var tmpSb = new StringBuilder();

                tmpSb.Append("Duplicate identifier `");
                tmpSb.Append(identifier);
                tmpSb.Append("`");

                throw new DuplicateIdentifierSGFParserException(tmpSb.ToString());
            }

            mNodesDict.Add(identifier, node);
        }

        public INode GetNode(string identifier)
        {
            if(mNodesDict.ContainsKey(identifier))
            {
                return mNodesDict[identifier];
            }

            var tmpSb = new StringBuilder();

            tmpSb.Append("Unexpected identifier `");
            tmpSb.Append(identifier);
            tmpSb.Append("`");

            throw new UnexpectedIdentifierSGFParserException(tmpSb.ToString());
        }
    }
}
