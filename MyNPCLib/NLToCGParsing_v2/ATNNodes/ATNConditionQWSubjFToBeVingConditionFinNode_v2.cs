using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeVingConditionFinNodeAction(ATNConditionQWSubjFToBeVingConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeVingConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeVingConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Ving_Condition_Fin;

        public ATNConditionQWSubjFToBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeVingConditionFinNodeAction mInitAction;

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

