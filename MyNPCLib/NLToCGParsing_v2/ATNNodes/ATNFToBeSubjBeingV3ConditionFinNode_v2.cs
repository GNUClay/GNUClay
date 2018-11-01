using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjBeingV3ConditionFinNodeAction(ATNFToBeSubjBeingV3ConditionFinNode_v2 item);

    public class ATNFToBeSubjBeingV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjBeingV3ConditionFinNodeFactory_v2(ATNFToBeSubjBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjBeingV3ConditionFinNodeFactory_v2(ATNFToBeSubjBeingV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjBeingV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjBeingV3TransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjBeingV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjBeingV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjBeingV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjBeingV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjBeingV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingV3ConditionFinNode_v2 sameNode, InitATNFToBeSubjBeingV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Being_V3_Condition_Fin;

        public ATNFToBeSubjBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjBeingV3ConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjBeingV3ConditionFinNodeAction mInitAction;

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

