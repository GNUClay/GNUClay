using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeConditionV3ConditionFinNodeAction(ATNQWSubjFToBeConditionV3ConditionFinNode_v2 item);

    public class ATNQWSubjFToBeConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeConditionV3ConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeConditionV3ConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionV3ConditionFinNode_v2 sameNode, InitATNQWSubjFToBeConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Condition_V3_Condition_Fin;

        public ATNQWSubjFToBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeConditionV3ConditionFinNodeAction mInitAction;

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

