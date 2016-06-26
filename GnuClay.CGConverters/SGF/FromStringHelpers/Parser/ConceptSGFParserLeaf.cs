using GnuClay.CG;
using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class ConceptSGFParserLeaf: BaseSGFParserLeaf
    {
        private enum State
        {
            Base,
            EndOfInstructions,
            AfterLabel,
            AfterColon
        }

        public ConceptSGFParserLeaf(SGFParserContext context)
            : this(context, null, null)
        {
        }

        public ConceptSGFParserLeaf(SGFParserContext context, SGFToken identifier, IConceptualNode parent)
            : base(context)
        {
            mParentConceptualNode = parent;

            mResult = Context.NodeFactory.CreateConceptualNode(mParentConceptualNode);

            if(!string.IsNullOrWhiteSpace(identifier?.Content))
            {
                Context.RegNode(identifier.Content, mResult);
            }         
        }

        private IConceptualNode mParentConceptualNode = null;

        private IConceptualNode mResult = null;

        public IConceptualNode Result
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

                case State.EndOfInstructions:
                    ProcessToken_InEndOfInstructions(token);
                    return;

                case State.AfterLabel:
                    ProcessToken_InAfterLabel(token);
                    return;

                case State.AfterColon:
                    ProcessToken_InAfterColon(token);
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBase(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.OpenFiguredBracket:
                    ProcessInstructions();

                    return;

                case SGFTokenKind.String:
                    mResult.FullName = token.Content;

                    mState = State.AfterLabel;

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessInstructions()
        {
            var tmpSubLeaf = new InstructionSGFParserLeaf(Context, mResult);

            tmpSubLeaf.Run();

            mState = State.EndOfInstructions;
        }

        private void ProcessToken_InEndOfInstructions(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.CloseSquareBracket:
                    Exit();
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterLabel(SGFToken token)
        {
            switch(token.Kind)
            {
                case SGFTokenKind.CloseSquareBracket:
                    Exit();
                    return;

                case SGFTokenKind.Colon:
                    mState = State.AfterColon;
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterColon(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.OpenFiguredBracket:
                    ProcessInstructions();
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }
    }
}
