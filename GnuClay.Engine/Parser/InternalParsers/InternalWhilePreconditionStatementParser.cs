using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalWhilePreconditionStatementParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            InCondition,
            GotCondition,
            AfterCondition,
            InBody,
            AfterBody
        }

        public InternalWhilePreconditionStatementParser(InternalParserContext context)
            : base(context)
        {
            mDataDictionary = Context.MainContext.DataDictionary;
            Result.WithPrecondition = true;
        }

        private StorageDataDictionary mDataDictionary = null;
        public ASTWhileStatement Result = new ASTWhileStatement();
        private State mState = State.Init;
        private Token LastOpenFigureBracketToken;

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
                        case TokenKind.OpenRoundBracket:
                            mState = State.InCondition;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.InCondition:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            ProcessCondition();
                            break;

                        case TokenKind.Var:
                            ProcessCondition();
                            break;

                        case TokenKind.Number:
                            ProcessCondition();
                            break;

                        case TokenKind.Tilde:
                            ProcessCondition();
                            break;

                        case TokenKind.Dash:
                            ProcessCondition();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotCondition:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseRoundBracket:
                            mState = State.AfterCondition;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterCondition:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            LastOpenFigureBracketToken = CurrToken;
                            mState = State.InBody;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.InBody:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            mState = State.AfterBody;
                            break;

                        default:
                            ProcessBody();
                            break;
                    }
                    break;

                case State.AfterBody:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Semicolon:
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }

        private void ProcessCondition()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessCondition");
#endif

            Context.Recovery(CurrToken);

            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, InternalCodeExpressionStatementParser.Mode.IsParameterOfFunction, true);
            tmpInternalCodeExpressionStatementParser.Run();

            Result.Condition = tmpInternalCodeExpressionStatementParser.ASTResult.Expression;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessCondition Result = {Result?.ToString(mDataDictionary, 0)}");
#endif

            mState = State.GotCondition;
        }

        private void ProcessBody()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBody mState = {mState}");
#endif
            Context.Recovery(LastOpenFigureBracketToken);
            Context.Recovery(CurrToken);

            var tmpInternalFunctionBodyParser = new InternalFunctionBodyParser(Context);
            tmpInternalFunctionBodyParser.Run();

            var tmpBody = tmpInternalFunctionBodyParser.Result;
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBody result = {tmpBody?.ToString(mDataDictionary, 0)}");
#endif
            Result.Body = tmpBody;
            mState = State.AfterBody;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessCondition Result = {Result?.ToString(mDataDictionary, 0)}");
#endif
        }
    }
}
