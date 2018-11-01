using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeBeingConditionV3ConditionFinNodeAction(ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeBeingConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeBeingConditionV3ConditionFinNodeFactory_v2(ATNConditionSubjFToBeBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeBeingConditionV3ConditionFinNodeFactory_v2(ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeBeingConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeBeingConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeBeingConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeBeingConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Being_Condition_V3_Condition_Fin;

        public ATNConditionSubjFToBeBeingConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeBeingConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeBeingConditionV3ConditionFinNodeAction mInitAction;

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

