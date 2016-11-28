using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalParserContext
    {
        public Lexer Lexer = null;
        public GnuClayEngineComponentContext MainContext = null;

        private Queue<Token> mRecoveriesTokens = new Queue<Token>();

        public Token GetToken()
        {
            if(mRecoveriesTokens.Count == 0)
            {
                return Lexer.GetToken();
            }

            return mRecoveriesTokens.Dequeue();
        }

        public void Recovery(Token token)
        {
            mRecoveriesTokens.Enqueue(token);
        }

        public bool IsEmpty()
        {
            var tmpToken = GetToken();

            if(tmpToken == null)
            {
                return true;
            }

            Recovery(tmpToken);

            return false;
        }
    }
}
