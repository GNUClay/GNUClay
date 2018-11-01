using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeVingConditionFinNodeAction(ATNConditionSubjFToBeVingConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeVingConditionFinNodeFactory_v2(ATNConditionSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeVingConditionFinNodeFactory_v2(ATNConditionSubjFToBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Ving_Condition_Fin;

        public ATNConditionSubjFToBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeVingConditionFinNodeAction mInitAction;

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

