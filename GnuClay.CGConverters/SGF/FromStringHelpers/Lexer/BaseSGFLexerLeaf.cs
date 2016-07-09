using GnuClay.CommonUtils.ParserHelpers;
using System.Text;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    public abstract class BaseSGFLexerLeaf
    {
        protected BaseSGFLexerLeaf(SGFLexerContext context)
        {
            mContext = context;
        }

        private SGFLexerContext mContext = null;

        protected SGFLexerContext Context
        {
            get
            {
                return mContext;
            }
        }

        public virtual void Run()
        {
            mMustExit = false;

            char tmpCurrChar;

            while((tmpCurrChar = mContext.GetChar()) != char.MinValue)
            {
                ProcessChar(tmpCurrChar);

                if(mMustExit)
                {
                    OnExit();

                    return;
                }
            }
        }

        private bool mMustExit = false;

        protected void Exit()
        {
            mMustExit = true;
        }

        protected virtual void ProcessChar(char ch)
        {
        }

        protected virtual void OnExit()
        {
        }

        public virtual SGFToken CreateToken()
        {
            var tmpRez = new SGFToken();

            tmpRez.Line = Context.Line;
            tmpRez.Pos = Context.Pos;

            return tmpRez;
        }

        public SGFToken CreateToken(SGFTokenKind kind, string content)
        {
            var tmpRez = CreateToken();

            tmpRez.Kind = kind;
            tmpRez.Content = content;

            return tmpRez;
        }

        protected UnexpectedSymbolException CreateUndefinedTokenException(char ch)
        {
            var tmpSb = new StringBuilder("Unexpected symbol `");
            tmpSb.Append(ch);
            tmpSb.Append("` at line ");
            tmpSb.Append(Context.Line);
            tmpSb.Append(" near at pos ");
            tmpSb.Append(Context.Pos);

            return new UnexpectedSymbolException(tmpSb.ToString());
        }
    }
}
