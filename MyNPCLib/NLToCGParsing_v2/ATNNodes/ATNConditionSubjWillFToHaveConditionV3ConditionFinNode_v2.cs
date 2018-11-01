using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveConditionV3ConditionFinNodeAction(ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Condition_V3_Condition_Fin;

        public ATNConditionSubjWillFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveConditionV3ConditionFinNodeAction mInitAction;

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

