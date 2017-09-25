using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalDefineDirectiveParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            WaitContent
        }

        public InternalDefineDirectiveParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;
        public GnuClayQuery Result = new GnuClayQuery();

        protected override void OnRun()
        {
            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            mState = State.WaitContent;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitContent:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            switch (CurrToken.KeyWordTokenKind)
                            {
                                case TokenKind.FUN:
                                    Result.Kind = GnuClayQueryKind.USER_DEFINED_FUNCTION;
                                    Context.Recovery(CurrToken);
                                    var tmpInternalFunctionDefinerParser = new InternalFunctionDefinerParser(Context);
                                    tmpInternalFunctionDefinerParser.Run();
                                    Result.UserDefinedFunction = tmpInternalFunctionDefinerParser.Result;
                                    break;

                                default: throw new UnexpectedTokenException(CurrToken);
                            }
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }
    }
}
