using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillFToHaveConditionV3ConditionFinNodeAction(ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNodeFactory_v2(ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillFToHaveConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillFToHaveConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillFToHaveConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_FToHave_Condition_V3_Condition_Fin;

        public ATNConditionQWSubjWillFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillFToHaveConditionV3ConditionFinNodeAction mInitAction;

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

