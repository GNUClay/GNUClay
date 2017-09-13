using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
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

                        case TokenKind.Word:
                            ProcessWordToken();
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

            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, InternalCodeExpressionStatementParser.Mode.General, true);
            tmpInternalCodeExpressionStatementParser.Run();
            AddStatement(tmpInternalCodeExpressionStatementParser.ASTResult);
        }

        private void ProcessWordToken()
        {
            switch (CurrToken.KeyWordTokenKind)
            {
                case TokenKind.Unknown:
                    ProcessExpressionStatement();
                    break;

                case TokenKind.IF:
                    {
#if PARSE_WITHOUT_ProbabilisticOfFunctionBody
                        var tmpInternalCodeExpressionStatementParser = new InternalIfStatementParser(Context);
                        tmpInternalCodeExpressionStatementParser.Run();
                        AddStatement(tmpInternalCodeExpressionStatementParser.Result);
#else
                        var tmpProbabilisticParsing = new InternalProbabilisticParsingOfFunctionBody(this);

                        tmpProbabilisticParsing.AddBranch((InternalParserContext context) => {
                            var tmpInternalCodeExpressionStatementParser = new InternalIfStatementParser(context);
                            tmpInternalCodeExpressionStatementParser.Run();
                            return tmpInternalCodeExpressionStatementParser.Result;
                        });
                        tmpProbabilisticParsing.AddBranch((InternalParserContext context) => {
                            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(context, InternalCodeExpressionStatementParser.Mode.General, true);
                            tmpInternalCodeExpressionStatementParser.Run();
                            return tmpInternalCodeExpressionStatementParser.ASTResult;
                        });

                        tmpProbabilisticParsing.Run();
                        AddStatement(tmpProbabilisticParsing.Result);
#endif

                    }
                    break;

                case TokenKind.WHILE:
                    {
#if PARSE_WITHOUT_ProbabilisticOfFunctionBody
                        var tmpInternalWhilePreconditionStatementParser = new InternalWhilePreconditionStatementParser(Context);
                        tmpInternalWhilePreconditionStatementParser.Run();
                        AddStatement(tmpInternalWhilePreconditionStatementParser.Result);
#else
                        var tmpProbabilisticParsing = new InternalProbabilisticParsingOfFunctionBody(this);

                        tmpProbabilisticParsing.AddBranch((InternalParserContext context) => {
                            var tmpInternalWhilePreconditionStatementParser = new InternalWhilePreconditionStatementParser(Context);
                            tmpInternalWhilePreconditionStatementParser.Run();
                            return tmpInternalWhilePreconditionStatementParser.Result;
                        });
                        tmpProbabilisticParsing.AddBranch((InternalParserContext context) => {
                            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(context, InternalCodeExpressionStatementParser.Mode.General, true);
                            tmpInternalCodeExpressionStatementParser.Run();
                            return tmpInternalCodeExpressionStatementParser.ASTResult;
                        });
                        tmpProbabilisticParsing.Run();
                        AddStatement(tmpProbabilisticParsing.Result);
#endif
                    }
                    break;

                default: throw new UnexpectedTokenException(CurrToken);
            }
        }

        private void AddStatement(ASTStatement statement)
        {
            if (statement != null)
            {
                Result.Statements.Add(statement);
            }
        }
    }
}
