using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotBeingConditionV3ConditionFinNodeAction(ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2 item);

    public class ATNSubjFToBeNotBeingConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotBeingConditionV3ConditionFinNodeFactory_v2(ATNSubjFToBeNotBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotBeingConditionV3ConditionFinNodeFactory_v2(ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotBeingConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotBeingConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotBeingConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2 sameNode, InitATNSubjFToBeNotBeingConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Being_Condition_V3_Condition_Fin;

        public ATNSubjFToBeNotBeingConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotBeingConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotBeingConditionV3ConditionFinNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

