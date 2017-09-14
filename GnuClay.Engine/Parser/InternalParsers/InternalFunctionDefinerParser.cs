using GnuClay.Engine.CommonStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalFunctionDefinerParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            WaitName
        }

        public InternalFunctionDefinerParser(InternalParserContext context)
            : base(context)
        {
            mDataDictionary = Context.MainContext.DataDictionary;
        }

        private StorageDataDictionary mDataDictionary = null;

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
                        case TokenKind.Word:
                            switch (CurrToken.KeyWordTokenKind)
                            {
                                case TokenKind.FUN:
                                    mState = State.WaitName;
                                    break;

                                default: throw new UnexpectedTokenException(CurrToken);
                            }
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitName:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }
    }
}
