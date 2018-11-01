using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotBeingConditionV3ConditionFinNodeAction(ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotBeingConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotBeingConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeNotBeingConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Being_Condition_V3_Condition_Fin;

        public ATNConditionSubjFToBeNotBeingConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotBeingConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotBeingConditionV3ConditionFinNodeAction mInitAction;

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

