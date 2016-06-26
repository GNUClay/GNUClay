using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    public class SGFLexerContext
    {
        public SGFLexerContext(List<char> text)
        {
            mBuffer = new Queue<char>(text);
        }

        private Queue<char> mBuffer = null;

        public char GetChar()
        {
            if(mBuffer.Count == 0)
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

        private List<SGFToken> mResultList = new List<SGFToken>();

        public void AddToken(SGFToken token)
        {
            mPos += token.Content.Length;

            mResultList.Add(token);
        }

        public List<SGFToken> ResultList
        {
            get
            {
                return mResultList;
            }
        }

        public void NewLine()
        {
            mLine++;
            mPos = 1;
        }

        private int mLine = 1;

        public int Line
        {
            get
            {
                return mLine;
            }
        }

        private int mPos = 1;

        public int Pos
        {
            get
            {
                return mPos;
            }
        }
    }
}
