using GnuClay.CommonUtils.ParserHelpers;
using GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameParser
{
    public abstract class NodeNameParserBaseLeaf
    {
        protected NodeNameParserBaseLeaf(NodeNameParserContext context)
        {
            mContext = context;
        }

        private NodeNameParserContext mContext = null;

        protected NodeNameParserContext Context
        {
            get
            {
                return mContext;
            }
        }

        public virtual void Run()
        {
            mMustExit = false;

            NodeNameToken tmpCurrToken = null;

            while ((tmpCurrToken = mContext.GetToken()) != null)
            {
                ProcessToken(tmpCurrToken);

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

        protected virtual void ProcessToken(NodeNameToken token)
        {
        }

        protected virtual void OnExit()
        {
        }

        protected virtual void OnExitIfEndOfString()
        {
        }

        protected UnexpectedTokenException CreateUnexpectedTokenException(NodeNameToken token)
        {
            var tmpSb = new StringBuilder("Unexpected token `");
            tmpSb.Append(token.Content);
            tmpSb.Append("`");

            return new UnexpectedTokenException(tmpSb.ToString());
        }
    }
}
