using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalSelectQueryParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            FirstStep,
            ParsingSelect,
            AfterParsingSelect
        }

        public InternalSelectQueryParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;

        public SelectQuery Result = new SelectQuery();

        protected override void OnRun()
        {
            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.SELECT:
                            mState = State.FirstStep;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.FirstStep:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            mState = State.ParsingSelect;
                            var tmpSelectQueryParser = new InternalSelectedTreeParser(Context);
                            tmpSelectQueryParser.Run();
                            Result.SelectedTree = tmpSelectQueryParser.Result;
                            mState = State.AfterParsingSelect;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }
    }
}
