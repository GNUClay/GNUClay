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

        protected override void OnRun()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.KeyWordTokenKind = {CurrToken.KeyWordTokenKind} CurrToken.Content = {CurrToken.Content}");
#endif

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
                                    Context.Recovery(CurrToken);
                                    var tmpInternalFunctionDefinerParser = new InternalFunctionDefinerParser(Context);
                                    tmpInternalFunctionDefinerParser.Run();
                                    throw new NotImplementedException();

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
