using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjBeingConditionV3ConditionFinNodeAction(ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjBeingConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjBeingConditionV3ConditionFinNodeFactory_v2(ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjBeingConditionV3ConditionFinNodeFactory_v2(ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjBeingConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjBeingConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjBeingConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Being_Condition_V3_Condition_Fin;

        public ATNConditionFToBeSubjBeingConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjBeingConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjBeingConditionV3ConditionFinNodeAction mInitAction;

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

