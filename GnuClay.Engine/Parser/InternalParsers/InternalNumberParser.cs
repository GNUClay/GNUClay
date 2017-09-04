using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalNumberParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            DeclareIntNumber,
            MaybeDeclareFloatNumber,
            MaybeDeclareNegativeNumber
        }

        public InternalNumberParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;
        private string mFullCurrentNumberContent = string.Empty;

        public double Result = 0;
        private CultureInfo mFormatProvider = new CultureInfo("en-GB");
        protected override void OnRun()
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.Content = {CurrToken.Content}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mFullCurrentNumberContent = {mFullCurrentNumberContent}");
#endif
            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            mFullCurrentNumberContent = CurrToken.Content;
                            mState = State.DeclareIntNumber;
                            break;

                        case TokenKind.Dash:
                            mFullCurrentNumberContent += "-";
                            mState = State.MaybeDeclareNegativeNumber;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.DeclareIntNumber:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Point:
                            mFullCurrentNumberContent += ".";
                            mState = State.MaybeDeclareFloatNumber;
                            break;

                        default:
                            Context.Recovery(CurrToken);
                            Exit();
                            break;
                    }
                    break;

                case State.MaybeDeclareFloatNumber:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            mFullCurrentNumberContent += CurrToken.Content;
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.MaybeDeclareNegativeNumber:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            mFullCurrentNumberContent += CurrToken.Content;
                            mState = State.DeclareIntNumber;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }

        protected override void OnFinish()
        {
            Result = double.Parse(mFullCurrentNumberContent, mFormatProvider);
        }
    }
}
