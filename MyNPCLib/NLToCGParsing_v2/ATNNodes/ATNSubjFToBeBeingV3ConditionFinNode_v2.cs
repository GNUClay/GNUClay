using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeBeingV3ConditionFinNodeAction(ATNSubjFToBeBeingV3ConditionFinNode_v2 item);

    public class ATNSubjFToBeBeingV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeBeingV3ConditionFinNodeFactory_v2(ATNSubjFToBeBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeBeingV3ConditionFinNodeFactory_v2(ATNSubjFToBeBeingV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeBeingV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeBeingV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeBeingV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeBeingV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeBeingV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeBeingV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeBeingV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingV3ConditionFinNode_v2 sameNode, InitATNSubjFToBeBeingV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Being_V3_Condition_Fin;

        public ATNSubjFToBeBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeBeingV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeBeingV3ConditionFinNodeAction mInitAction;

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

