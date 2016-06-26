using GnuClay.CG;
using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class InstructionSGFParserLeaf : BaseSGFParserLeaf
    {
        private enum State
        {
            Base,
            AfterIdentifier,
            AfterColon,
            AfterConceptOrInstruction
        }

        public InstructionSGFParserLeaf(SGFParserContext context, IConceptualNode parent)
            : base(context)
        {
            mParentConceptualNode = parent;
        }

        private IConceptualNode mParentConceptualNode = null;

        private State mState = State.Base;

        private SGFToken mIdentifier = null;

        protected override void ProcessToken(SGFToken token)
        {
            switch (mState)
            {
                case State.Base:
                    ProcessToken_InBase(token);
                    return;

                case State.AfterIdentifier:
                    ProcessToken_InAfterIdentifier(token);
                    return;

                case State.AfterColon:
                    ProcessToken_InAfterColon(token);
                    return;

                case State.AfterConceptOrInstruction:
                    ProcessToken_InAfterConceptOrInstruction(token);
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBase(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.Identifier:
                    mIdentifier = token;

                    mState = State.AfterIdentifier;
                    return;

                case SGFTokenKind.CloseFiguredBracket:
                    Exit();
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterIdentifier(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.Colon:
                    mState = State.AfterColon;
                    return;

                case SGFTokenKind.RightArrow:
                    var tmpLink_1 = new LinkSGFParserLeaf(Context, mIdentifier, token);

                    tmpLink_1.Run();

                    mState = State.Base;

                    return;

                case SGFTokenKind.LeftArrow:
                    var tmpLink_2 = new LinkSGFParserLeaf(Context, mIdentifier, token);

                    tmpLink_2.Run();

                    mState = State.Base;

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterColon(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.OpenSquareBracket:
                    var tmpSubLeaf = new ConceptSGFParserLeaf(Context, mIdentifier, mParentConceptualNode);

                    tmpSubLeaf.Run();

                    mState = State.AfterConceptOrInstruction;

                    return;

                case SGFTokenKind.OpenRoundBracket:
                    var tmpSubLeaf_2 = new RelationSGFParserLeaf(Context, mIdentifier, mParentConceptualNode);

                    tmpSubLeaf_2.Run();

                    mState = State.AfterConceptOrInstruction;

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterConceptOrInstruction(SGFToken token)
        {
            switch(token.Kind)
            {
                case SGFTokenKind.Semicolon:

                    mState = State.Base;

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }
    }
}
