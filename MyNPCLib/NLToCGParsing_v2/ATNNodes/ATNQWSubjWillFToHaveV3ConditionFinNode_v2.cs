using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveV3ConditionFinNodeAction(ATNQWSubjWillFToHaveV3ConditionFinNode_v2 item);

    public class ATNQWSubjWillFToHaveV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveV3ConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveV3ConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveV3TransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillFToHaveV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveV3ConditionFinNode_v2 sameNode, InitATNQWSubjWillFToHaveV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_V3_Condition_Fin;

        public ATNQWSubjWillFToHaveV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveV3ConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveV3ConditionFinNodeAction mInitAction;

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

