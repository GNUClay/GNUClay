using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class ParsingContext
    {
        public Lexer Lexer = null;
        public GnuClayEngineComponentContext MainContext = null;
        public BaseParserHandler CurrentHandler = null;

        public void PushHandler(BaseParserHandler handler)
        {
            if(CurrentHandler != null)
            {
                mHandlersStack.Push(CurrentHandler);
            }

            CurrentHandler = handler;
        }

        public void PopHandler()
        {
            if(mHandlersStack.Count == 0)
            {
                CurrentHandler = null;
            }
            else
            {
                CurrentHandler = mHandlersStack.Pop();
                CurrentHandler.OnFinishChildHandler();
            }
        }

        private Stack<BaseParserHandler> mHandlersStack = new Stack<BaseParserHandler>();
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
    }
}
