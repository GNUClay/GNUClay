using GnuClay.CommonUtils.ParserHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public abstract class NodeNameLexerBaseLeaf
    {
        protected NodeNameLexerBaseLeaf(NodeNameLexerContext context)
        {
            mContext = context;
        }

        private NodeNameLexerContext mContext = null;

        protected NodeNameLexerContext Context
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

            while ((tmpCurrChar = mContext.GetChar()) != char.MinValue)
            {
                ProcessChar(tmpCurrChar);

                if (mMustExit)
                {
                    OnExit();

                    return;
                }
            }

            OnExitIfEndOfString();
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

        protected virtual void OnExitIfEndOfString()
        {
        }

        public NodeNameToken CreateToken(NodeNameTokenKind kind, string content)
        {
            var tmpRez = new NodeNameToken();

            tmpRez.Kind = kind;
            tmpRez.Content = content;

            return tmpRez;
        }

        protected UnexpectedSymbolException CreateUndefinedTokenException(char ch)
        {
            var tmpSb = new StringBuilder("Unexpected symbol `");
            tmpSb.Append(ch);
            tmpSb.Append("`");

            return new UnexpectedSymbolException(tmpSb.ToString());
        }
    }
}
