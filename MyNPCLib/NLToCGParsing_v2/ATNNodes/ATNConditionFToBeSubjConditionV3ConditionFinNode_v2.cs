using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjConditionV3ConditionFinNodeAction(ATNConditionFToBeSubjConditionV3ConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjConditionV3ConditionFinNodeFactory_v2(ATNConditionFToBeSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjConditionV3ConditionFinNodeFactory_v2(ATNConditionFToBeSubjConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionV3ConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Condition_V3_Condition_Fin;

        public ATNConditionFToBeSubjConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjConditionV3ConditionFinNodeAction mInitAction;

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

