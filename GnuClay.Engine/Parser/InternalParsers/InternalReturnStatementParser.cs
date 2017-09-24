using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalReturnStatementParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            GotValue
        }

        public InternalReturnStatementParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;
        public ASTReturnStatement Result = new ASTReturnStatement();

        protected override void OnRun()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.Content = {CurrToken.Content}");
#endif

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                        case TokenKind.Var:
                        case TokenKind.SystemVar:
                        case TokenKind.Word:
                        case TokenKind.Tilde:
                            ParseExpression();
                            break;

                        case TokenKind.Semicolon:
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotValue:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            Context.Recovery(CurrToken);
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }

        private void ParseExpression()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ParseExpression");
#endif

            Context.Recovery(CurrToken);

            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, InternalCodeExpressionStatementParser.Mode.General, true);
            tmpInternalCodeExpressionStatementParser.Run();

            Result.Expression = tmpInternalCodeExpressionStatementParser.ASTResult.Expression;

            mState = State.GotValue;
        }
    }
}
