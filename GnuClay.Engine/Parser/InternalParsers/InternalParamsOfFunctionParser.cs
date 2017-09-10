using GnuClay.Engine.CommonStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalParamsOfFunctionParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            AfterParam,
            WaitParam
        }

        public InternalParamsOfFunctionParser(InternalParserContext context)
            : base(context)
        {
            mDataDictionary = Context.MainContext.DataDictionary;
        }

        private State mState = State.Init;
        private StorageDataDictionary mDataDictionary = null;
        public List<InternalCodeExpressionNode> Result = new List<InternalCodeExpressionNode>();

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
                        case TokenKind.Word:
                            ProcessParam();
                            break;

                        case TokenKind.Var:
                            ProcessParam();
                            break;

                        case TokenKind.Number:
                            ProcessParam();
                            break;

                        case TokenKind.Tilde:
                            ProcessParam();
                            break;

                        case TokenKind.Dash:
                            ProcessParam();
                            break;

                        case TokenKind.CloseRoundBracket:
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterParam:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Comma:
                            mState = State.WaitParam;
                            break;

                        case TokenKind.CloseRoundBracket:
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitParam:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            ProcessParam();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }

        private void ProcessParam()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessParam");
#endif

            Context.Recovery(CurrToken);
            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, InternalCodeExpressionStatementParser.Mode.IsParameterOfFunction);
            tmpInternalCodeExpressionStatementParser.Run();

            var tmpNode = tmpInternalCodeExpressionStatementParser.RootNode;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessParam tmpNode = {tmpNode?.ToString(mDataDictionary, 0)}");
#endif
            Result.Add(tmpNode);
            mState = State.AfterParam;
        }
    }
}
