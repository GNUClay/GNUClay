using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public class NodeNameLexerContext
    {
        public NodeNameLexerContext(List<char> text)
        {
            mBuffer = new Queue<char>(text);
        }

        private Queue<char> mBuffer = null;

        public char GetChar()
        {
            if (mBuffer.Count == 0)
            {
                return char.MinValue;
            }

            return mBuffer.Dequeue();
        }

        public void Recovery(char ch)
        {
            var tmpNewList = new List<char>() { ch };

            if (mBuffer.Count > 0)
            {
                tmpNewList.AddRange(mBuffer.ToList());
            }

            mBuffer = new Queue<char>(tmpNewList);
        }

        private List<NodeNameToken> mResultList = new List<NodeNameToken>();

        public void AddToken(NodeNameToken token)
        {
            mResultList.Add(token);
        }

        public List<NodeNameToken> ResultList
        {
            get
            {
                return mResultList;
            }
        }
    }
}
