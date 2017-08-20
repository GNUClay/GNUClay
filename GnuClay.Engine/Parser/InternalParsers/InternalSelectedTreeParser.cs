using GnuClay.Engine.LogicalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalSelectedTreeParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            WaitRuleHeadExpression,
            GotRuleHeadExpression,
            EndHead
        }

        public InternalSelectedTreeParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;

        private ExpressionNode mRootNode = null;

        public ExpressionNode Result
        {
            get
            {
                return mRootNode;
            }
        }

        protected override void OnRun()
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.Content = {CurrToken.Content}");
#endif

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.RULE_HEAD:
                            mState = State.WaitRuleHeadExpression;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitRuleHeadExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            var tmpInternalExpressionParser = new InternalLogicalExpressionParser(Context, null);
                            tmpInternalExpressionParser.Run();

                            mRootNode = tmpInternalExpressionParser.Result;

                            mState = State.GotRuleHeadExpression;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotRuleHeadExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            mState = State.EndHead;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.EndHead:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState.ToString());
            }
        }
    }
}
