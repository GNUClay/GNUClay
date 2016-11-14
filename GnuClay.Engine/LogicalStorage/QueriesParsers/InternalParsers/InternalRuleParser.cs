using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.CommonData;
using GnuClay.Engine.LogicalStorage.InternalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    class InternalRuleParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            WaitRuleHeadExpression,
            GotRuleHeadExpression,
            EndHead,
            WaitRuleBodyExpression,
            GotRuleBodyExpression,
            EndBody
        }

        public InternalRuleParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;

        public RuleInstance Result = new RuleInstance();
        private RulePart Part_1 = null;
        private RulePart Part_2 = null;

        private StorageDataDictionary mLocalDataDictionary = new StorageDataDictionary(null);

        protected override void OnRun()
        {
            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.RULE_HEAD:
                            mState = State.WaitRuleHeadExpression;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.WaitRuleHeadExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            var tmpInternalExpressionParser = new InternalExpressionParser(Context, mLocalDataDictionary);
                            tmpInternalExpressionParser.Run();
                            Part_1 = new RulePart();
                            Result.Part_1 = Part_1;
                            Part_1.Parent = Result;
                            Part_1.Tree = tmpInternalExpressionParser.Result;
                            mState = State.GotRuleHeadExpression;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.GotRuleHeadExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            mState = State.EndHead;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.EndHead:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.RULE_BODY:
                            mState = State.WaitRuleBodyExpression;
                            break;

                        case TokenKind.CloseFigureBracket:
                            Context.Recovery(CurrToken);
                            Exit();
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.WaitRuleBodyExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            var tmpInternalExpressionParser = new InternalExpressionParser(Context, mLocalDataDictionary);
                            tmpInternalExpressionParser.Run();
                            Part_2 = new RulePart();
                            Result.Part_2 = Part_2;
                            Part_2.Parent = Result;
                            Part_2.Tree = tmpInternalExpressionParser.Result;

                            Part_1.Next = Part_2;
                            Part_2.Next = Part_1;

                            mState = State.GotRuleBodyExpression;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.GotRuleBodyExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            mState = State.EndBody;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.EndBody:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            Context.Recovery(CurrToken);
                            Exit();
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }
    }
}
