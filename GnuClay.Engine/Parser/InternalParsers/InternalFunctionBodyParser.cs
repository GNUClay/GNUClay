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
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun {CurrToken} {mState}");

            switch (mState)
            {
                case State.Init:
                    switch(CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            mState = State.BeginInstruction;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.BeginInstruction:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            ProcessExpressionStatement();
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }

        private void ProcessExpressionStatement()
        {
            Context.Recovery(CurrToken);

            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, false);
            tmpInternalCodeExpressionStatementParser.Run();
            Result.Statements.Add(tmpInternalCodeExpressionStatementParser.Result);
        }
    }
}
