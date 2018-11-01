using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionV3ConditionFinNodeAction(ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionV3ConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionV3ConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_V3_Condition_Fin;

        public ATNConditionQWSubjFToBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionV3ConditionFinNodeAction mInitAction;

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

