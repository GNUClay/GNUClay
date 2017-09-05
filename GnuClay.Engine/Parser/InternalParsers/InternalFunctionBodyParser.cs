using GnuClay.Engine.ScriptExecutor.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalFunctionBodyParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            BeginInstruction
        }

        public InternalFunctionBodyParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;
        public ASTCodeBlock Result = new ASTCodeBlock();

        protected override void OnRun()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.Content = {CurrToken.Content}");
#endif

            switch (mState)
            {
                case State.Init:
                    switch(CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            mState = State.BeginInstruction;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.BeginInstruction:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            ProcessExpressionStatement();
                            break;

                        case TokenKind.Var:
                            ProcessExpressionStatement();
                            break;

                        case TokenKind.CloseFigureBracket:
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }

        private void ProcessExpressionStatement()
        {
            Context.Recovery(CurrToken);

            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, InternalCodeExpressionStatementParser.Mode.General);
            tmpInternalCodeExpressionStatementParser.Run();
            var astResult = tmpInternalCodeExpressionStatementParser.ASTResult;

            if(astResult != null)
            {
                Result.Statements.Add(astResult);
            }
        }
    }
}
