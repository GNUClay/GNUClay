using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    //InternalRuleParser
    public class InternalRuleParserHandler : BaseParserHandler
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

        public InternalRuleParserHandler(ParsingContext context)
            : base(context)
        {
        }

        private State mState = State.Init;

        public RuleInstance Result = new RuleInstance();
        private RulePart Part_1 = null;
        private RulePart Part_2 = null;

        private StorageDataDictionary mLocalDataDictionary = new StorageDataDictionary(null);

        public override void Dispatch(Token token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Dispatch token = `{token}` {mState}");

            switch (mState)
            {
                case State.Init:
                    switch (token.TokenKind)
                    {
                        case TokenKind.RULE_HEAD:
                            mState = State.WaitRuleHeadExpression;
                            break;

                        default: throw new UndefinedTokenException(token.TokenKind);
                    }
                    break;

                case State.WaitRuleHeadExpression:
                    switch (token.TokenKind)
                    {


                        default: throw new UndefinedTokenException(token.TokenKind);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }
    }
}
