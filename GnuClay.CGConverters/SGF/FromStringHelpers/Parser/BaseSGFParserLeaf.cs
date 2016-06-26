using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public abstract class BaseSGFParserLeaf
    {
        protected BaseSGFParserLeaf(SGFParserContext context, bool mayExitOnEmptyBuffer = false)
        {
            mContext = context;
            mMayExitOnEmptyBuffer = false;
        }

        private SGFParserContext mContext = null;

        private bool mMayExitOnEmptyBuffer = false;

        protected SGFParserContext Context
        {
            get
            {
                return mContext;
            }
        }

        public virtual void Run()
        {
            mMustExit = false;

            SGFToken tmpCurrToken = null;

            SGFToken tmpLastToken = null;

            while ((tmpCurrToken = mContext.GetToken()) != null)
            {
                tmpLastToken = tmpCurrToken;

                ProcessToken(tmpCurrToken);

                if (mMustExit)
                {
                    OnExit();

                    return;
                }
            }

            if(!mMayExitOnEmptyBuffer)
            {
                var tmpErrToken = new SGFToken();

                if(tmpLastToken != null)
                {
                    tmpErrToken.Line = tmpLastToken.Line;
                    tmpErrToken.Pos = tmpLastToken.Pos;
                }

                throw CreateUnexpectedTokenException(tmpErrToken);
            }

            OnExit();
        }

        private bool mMustExit = false;

        protected void Exit()
        {
            mMustExit = true;
        }

        protected virtual void ProcessToken(SGFToken token)
        {
        }

        protected virtual void OnExit()
        {
        }

        protected UnexpectedTokenSGFParserException CreateUnexpectedTokenException(SGFToken token)
        {
            var tmpSb = new StringBuilder("Unexpected token `");
            tmpSb.Append(token.Content);
            tmpSb.Append("` at line ");
            tmpSb.Append(token.Line);
            tmpSb.Append(" near at pos ");
            tmpSb.Append(token.Pos);

            return new UnexpectedTokenSGFParserException(tmpSb.ToString());
        }
    }
}
