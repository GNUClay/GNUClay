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

        public InternalRuleParser(InternalParserContext context, ulong targetKey)
            : base(context)
        {
            Result = new RuleInstance();
            Result.Key = targetKey;

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"constructor targetKey = {targetKey}  {context.MainContext.DataDictionary.GetValue(targetKey)}");
            //if(targetKey > 0)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"constructor NameOfRule = {context.MainContext.DataDictionary.GetValue(targetKey)}");
            //}
#endif
        }

        private State mState = State.Init;

        public RuleInstance Result = null;
        private RulePart Part_1 = null;
        private RulePart Part_2 = null;

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
                            var tmpInternalExpressionParser = new InternalLogicalExpressionParser(Context, Result.LocalKeysOfReferencesIndexes);
                            tmpInternalExpressionParser.Run();
                            Part_1 = new RulePart();
                            Result.Part_1 = Part_1;
                            Part_1.Parent = Result;
                            Part_1.Tree = tmpInternalExpressionParser.Result;                                                 
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
                            var tmpInternalExpressionParser = new InternalLogicalExpressionParser(Context, Result.LocalKeysOfReferencesIndexes);
                            tmpInternalExpressionParser.Run();
                            Part_2 = new RulePart();
                            Result.Part_2 = Part_2;
                            Part_2.Parent = Result;
                            Part_2.Tree = tmpInternalExpressionParser.Result;

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
    }
}
