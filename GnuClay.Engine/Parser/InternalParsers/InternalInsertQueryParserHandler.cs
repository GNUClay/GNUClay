using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    //InternalInsertQueryParser
    public class InternalInsertQueryParserHandler: BaseParserHandler
    {
        private enum State
        {
            Init,
            WaitRule,
            GotRule,
            EndRule
        }

        public InternalInsertQueryParserHandler(ParsingContext context)
            : base(context)
        {
        }

        private State mState = State.Init;

        public override void Dispatch(Token token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Dispatch token = `{token}` {mState}");

            switch (mState)
            {
                case State.Init:
                    switch (token.TokenKind)
                    {
                        case TokenKind.INSERT:
                            mState = State.WaitRule;
                            break;

                        default: throw new UndefinedTokenException(token.TokenKind);
                    }
                    break;

                case State.WaitRule:
                    switch (token.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            Context.PushHandler(new InternalRuleParserHandler(Context));
                            break;

                        default: throw new UndefinedTokenException(token.TokenKind);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }

        public override void OnFinishChildHandler()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnFinishChildHandler");

            switch(mState)
            {
                case State.WaitRule:
                    mState = State.GotRule;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }
    }
}
