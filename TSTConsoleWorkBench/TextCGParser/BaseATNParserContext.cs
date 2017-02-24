using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public abstract class BaseATNParserContext
    {
        protected BaseATNParserContext(List<ExtendToken> tokens)
        {
            mTokens = new Queue<ExtendToken>(tokens);
        }

        protected BaseATNParserContext(BaseATNParserContext source)
        {
            mTokens = new Queue<ExtendToken>(source.mTokens);
            mRecoveriesTokens = new Queue<ExtendToken>(source.mRecoveriesTokens);
        }

        protected Queue<ExtendToken> mTokens = null;
        protected Queue<ExtendToken> mRecoveriesTokens = new Queue<ExtendToken>();

        public ExtendToken GetToken()
        {
            if (mRecoveriesTokens.Count == 0)
            {
                if (mTokens.Count == 0)
                {
                    return null;
                }

                return mTokens.Dequeue();
            }

            return mRecoveriesTokens.Dequeue();
        }

        public void Recovery(ExtendToken token)
        {
            mRecoveriesTokens.Enqueue(token);
        }
    }
}
