using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjV3ConditionFinNodeAction(ATNFToHaveSubjV3ConditionFinNode_v2 item);

    public class ATNFToHaveSubjV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjV3ConditionFinNodeFactory_v2(ATNFToHaveSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjV3ConditionFinNodeFactory_v2(ATNFToHaveSubjV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjV3TransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToHaveSubjV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjV3ConditionFinNode_v2 sameNode, InitATNFToHaveSubjV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_V3_Condition_Fin;

        public ATNFToHaveSubjV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjV3ConditionFinNode_v2 mSameNode;
        private InitATNFToHaveSubjV3ConditionFinNodeAction mInitAction;

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

