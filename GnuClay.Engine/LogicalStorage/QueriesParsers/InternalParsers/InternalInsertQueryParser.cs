using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    public class InternalInsertQueryParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            WaitRule,
            GotRule,
            EndRule
        }

        public InternalInsertQueryParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;

        public InsertQuery Result = new InsertQuery();

        protected override void OnRun()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CurrToken = {CurrToken.TokenKind} mState = {mState}");

            switch(mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.INSERT:
                            mState = State.WaitRule;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.WaitRule:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            var tmpInternalRuleParser = new InternalRuleParser(Context);
                            tmpInternalRuleParser.Run();
                            Result.Items.Add(tmpInternalRuleParser.Result);
                            mState = State.GotRule;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.GotRule:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            mState = State.EndRule;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.EndRule:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Comma:
                            mState = State.WaitRule;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                default:throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }
    }
}
