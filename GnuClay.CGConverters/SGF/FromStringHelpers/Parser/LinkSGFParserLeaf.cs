using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class LinkSGFParserLeaf : BaseSGFParserLeaf
    {
        private enum State
        {
            AfterIdentifier,
            AfterArrow
        }

        public LinkSGFParserLeaf(SGFParserContext context, SGFToken firstIdentifier, SGFToken firstArrow)
            : base(context)
        {
            mFirstdentifier = firstIdentifier;
            mArrow = firstArrow;
        }

        private State mState = State.AfterArrow;

        private SGFToken mFirstdentifier = null;
        private SGFToken mArrow = null;

        protected override void ProcessToken(SGFToken token)
        {
            switch (mState)
            {
                case State.AfterIdentifier:
                    ProcessToken_InAfterIdentifier(token);
                    return;

                case State.AfterArrow:
                    ProcessToken_InAfterArrow(token);
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterIdentifier(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.LeftArrow:
                    mArrow = token;

                    mState = State.AfterArrow;

                    return;

                case SGFTokenKind.RightArrow:
                    mArrow = token;

                    mState = State.AfterArrow;
                    return;

                case SGFTokenKind.Semicolon:
                    Exit();
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterArrow(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.Identifier:
                    Linking(token);

                    mState = State.AfterIdentifier;

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void Linking(SGFToken secondIdentifier)
        {
            var tmpFirstNode = Context.GetNode(mFirstdentifier.Content);

            var tmpSecondNode = Context.GetNode(secondIdentifier.Content);

            switch(mArrow.Kind)
            {
                case SGFTokenKind.LeftArrow:
                    tmpFirstNode.AddInputNode(tmpSecondNode);
                    break;

                case SGFTokenKind.RightArrow:
                    tmpSecondNode.AddInputNode(tmpFirstNode);
                    break;
            }

            mArrow = null;

            mFirstdentifier = secondIdentifier;
        }
    }
}
