using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjV3ConditionFinNodeAction(ATNFToBeSubjV3ConditionFinNode_v2 item);

    public class ATNFToBeSubjV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjV3ConditionFinNodeFactory_v2(ATNFToBeSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjV3ConditionFinNodeFactory_v2(ATNFToBeSubjV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjV3TransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjV3ConditionFinNode_v2 sameNode, InitATNFToBeSubjV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_V3_Condition_Fin;

        public ATNFToBeSubjV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjV3ConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjV3ConditionFinNodeAction mInitAction;

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

