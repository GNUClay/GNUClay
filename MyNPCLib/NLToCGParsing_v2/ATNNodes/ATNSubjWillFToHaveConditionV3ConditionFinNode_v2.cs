using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveConditionV3ConditionFinNodeAction(ATNSubjWillFToHaveConditionV3ConditionFinNode_v2 item);

    public class ATNSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2(ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2(ATNSubjWillFToHaveConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillFToHaveConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveConditionV3ConditionFinNode_v2 sameNode, InitATNSubjWillFToHaveConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Condition_V3_Condition_Fin;

        public ATNSubjWillFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjWillFToHaveConditionV3ConditionFinNodeAction mInitAction;

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

