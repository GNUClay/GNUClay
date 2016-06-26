using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using GnuClay.CG;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Parser
{
    public class MainSGFParserLeaf: BaseSGFParserLeaf
    {
        private enum State
        {
            Base,
            AfterConcept
        }

        public MainSGFParserLeaf(SGFParserContext context)
            : base(context)
        {
        }

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
            switch(mState)
            {
                case State.Base:
                    ProcessToken_InBase(token);
                    return;

                case State.AfterConcept:
                    ProcessToken_InAfterConcept(token);
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InBase(SGFToken token)
        {
            switch(token.Kind)
            {
                case SGFTokenKind.OpenSquareBracket:
                    var tmpSubLeaf = new ConceptSGFParserLeaf(Context);

                    tmpSubLeaf.Run();

                    mResult = tmpSubLeaf.Result;

                    mState = State.AfterConcept;

                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }

        private void ProcessToken_InAfterConcept(SGFToken token)
        {
            switch (token.Kind)
            {
                case SGFTokenKind.Semicolon:
                    Exit();
                    return;
            }

            throw CreateUnexpectedTokenException(token);
        }
    }
}
