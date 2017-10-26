using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalDeleteQueryParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            FirstStep,
            ParsingQuery,
            AfterParsingQuery
        }

        public InternalDeleteQueryParser(InternalParserContext context)
             : base(context)
        {
        }

        private State mState = State.Init;

        public SelectQuery Result = new SelectQuery();

        protected override void OnRun()
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.KeyWordTokenKind = {CurrToken.KeyWordTokenKind} CurrToken.Content = {CurrToken.Content}");
#endif

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            switch(CurrToken.KeyWordTokenKind)
                            {
                                case TokenKind.READ:
                                    mState = State.FirstStep;
                                    break;

                                case TokenKind.DELETE:
                                    Result.SelectDirectFactsOnly = true;
                                    Result.IsDeleteQuery = true;
                                    mState = State.FirstStep;
                                    break;

                                default: throw new UnexpectedTokenException(CurrToken);
                            }
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.FirstStep:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            mState = State.ParsingQuery;
                            var tmpSelectQueryParser = new InternalSelectedTreeParser(Context);
                            tmpSelectQueryParser.Run();
                            Result.SelectedTree = tmpSelectQueryParser.Result;
                            mState = State.AfterParsingQuery;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState.ToString());
            }
        }
    }
}
