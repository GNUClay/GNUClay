using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotBeingV3ConditionFinNodeAction(ATNSubjFToBeNotBeingV3ConditionFinNode_v2 item);

    public class ATNSubjFToBeNotBeingV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotBeingV3ConditionFinNodeFactory_v2(ATNSubjFToBeNotBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotBeingV3ConditionFinNodeFactory_v2(ATNSubjFToBeNotBeingV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotBeingV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotBeingV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeNotBeingV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotBeingV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotBeingV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotBeingV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeNotBeingV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotBeingV3ConditionFinNode_v2 sameNode, InitATNSubjFToBeNotBeingV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Being_V3_Condition_Fin;

        public ATNSubjFToBeNotBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotBeingV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotBeingV3ConditionFinNodeAction mInitAction;

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

