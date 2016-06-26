using GnuClay.CG;
using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class RelationSGFParserLeaf : BaseSGFParserLeaf
    {
        private enum State
        {
            Base,
            AfterLabel
        }

        public RelationSGFParserLeaf(SGFParserContext context, SGFToken identifier, IConceptualNode parent)
            : base(context)
        {
            mParentConceptualNode = parent;

            mResult = Context.NodeFactory.CreateRelationNode(mParentConceptualNode);

            Context.RegNode(identifier.Content, mResult);
        }

        private IConceptualNode mParentConceptualNode = null;

        private IRelationNode mResult = null;

        public IRelationNode Result
        {
            get
            {
                return mResult;
            }
        }

        private State mState = State.Base;

        protected override void ProcessToken(SGFToken token)
        {
            switch (mState)
            {
                case State.Base:
                    ProcessToken_InBase(token);
                    return;

                case State.AfterLabel:
                    ProcessToken_InAfterLabel(token);
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBase(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.String:
                    mResult.FullName = token.Content;

                    mState = State.AfterLabel;

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterLabel(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.CloseRoundBracket:
                    Exit();
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }
    }
}
