using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeVingConditionFinNodeAction(ATNQWSubjFToBeVingConditionFinNode_v2 item);

    public class ATNQWSubjFToBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeVingConditionFinNodeFactory_v2(ATNQWSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeVingConditionFinNodeFactory_v2(ATNQWSubjFToBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingConditionFinNode_v2 sameNode, InitATNQWSubjFToBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Ving_Condition_Fin;

        public ATNQWSubjFToBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeVingConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeVingConditionFinNodeAction mInitAction;

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

