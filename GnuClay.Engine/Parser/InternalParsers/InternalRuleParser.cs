using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalRuleParser : BaseInternalParser
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

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitRuleHeadExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            var tmpInternalExpressionParser = new InternalLogicalExpressionParser(Context);
                            tmpInternalExpressionParser.Run();
                            Part_1 = new RulePart();
                            Result.Part_1 = Part_1;
                            Part_1.Parent = Result;
                            {
                                var result = tmpInternalExpressionParser.Result;
                                Part_1.Tree = result.RootNode;
                                AddLocalKeysOfReferencesIndexes(result.LocalKeysOfReferencesIndexes);
                            }
                                                 
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
                        case TokenKind.RULE_BODY:
                            mState = State.WaitRuleBodyExpression;
                            break;

                        case TokenKind.CloseFigureBracket:
                            Context.Recovery(CurrToken);
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitRuleBodyExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenFigureBracket:
                            var tmpInternalExpressionParser = new InternalLogicalExpressionParser(Context);
                            tmpInternalExpressionParser.Run();
                            Part_2 = new RulePart();
                            Result.Part_2 = Part_2;
                            Part_2.Parent = Result;
                            {
                                var result = tmpInternalExpressionParser.Result;
                                Part_2.Tree = result.RootNode;
                                AddLocalKeysOfReferencesIndexes(result.LocalKeysOfReferencesIndexes);
                            }
                            Part_1.Next = Part_2;
                            Part_2.Next = Part_1;

                            mState = State.GotRuleBodyExpression;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotRuleBodyExpression:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            mState = State.EndBody;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.EndBody:
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

        private void AddLocalKeysOfReferencesIndexes(Dictionary<ulong, ExpressionNode> values)
        {
            if(values.Count == 0)
            {
                return;
            }

            var localKeysOfReferencesIndexes = Result.LocalKeysOfReferencesIndexes;

            foreach (var item in values)
            {
                if(localKeysOfReferencesIndexes.ContainsKey(item.Key))
                {
                    throw new NotSupportedException();
                }

                localKeysOfReferencesIndexes[item.Key] = item.Value;
            }
        }
    }
}
