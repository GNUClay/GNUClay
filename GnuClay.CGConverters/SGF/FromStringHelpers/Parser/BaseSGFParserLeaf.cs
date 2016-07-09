using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using GnuClay.CommonUtils.ParserHelpers;
using System.Text;

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

        protected UnexpectedTokenException CreateUnexpectedTokenException(SGFToken token)
        {
            var tmpSb = new StringBuilder("Unexpected token `");
            tmpSb.Append(token.Content);
            tmpSb.Append("` at line ");
            tmpSb.Append(token.Line);
            tmpSb.Append(" near at pos ");
            tmpSb.Append(token.Pos);

            return new UnexpectedTokenException(tmpSb.ToString());
        }
    }
}
