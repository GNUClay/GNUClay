using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Parser.CommonData;
using System;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalInsertQueryParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            AfterName,
            WaitRule,
            GotRule,
            EndRule
        }

        public InternalInsertQueryParser(InternalParserContext context)
            : base(context)
        {
            mDataDictionary = context.MainContext.DataDictionary;
            Context.ListOfInlineFacts = Result.Items;
        }

        private StorageDataDictionary mDataDictionary = null;
        private State mState = State.Init;      
        private ulong mCurrentReferenceVariable = 0;

        public InsertQuery Result = new InsertQuery();

        protected override void OnRun()
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.Content = {CurrToken.Content} mCurrentReferenceVariable = {mCurrentReferenceVariable}");
#endif

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.INSERT:
                            mState = State.WaitRule;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterName:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Colon:
                            mState = State.WaitRule;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitRule:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            var tmpInternalRuleParser = new InternalRuleParser(Context, mCurrentReferenceVariable);
                            mCurrentReferenceVariable = 0;
                            tmpInternalRuleParser.Run();
                            Result.Items.Add(tmpInternalRuleParser.Result);
                            mState = State.GotRule;
                            break;

                        case TokenKind.Word:
                            mCurrentReferenceVariable = mDataDictionary.GetKey(CurrToken.Content);
                            mState = State.AfterName;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotRule:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            mState = State.EndRule;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.EndRule:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Comma:
                            mState = State.WaitRule;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }
    }
}
