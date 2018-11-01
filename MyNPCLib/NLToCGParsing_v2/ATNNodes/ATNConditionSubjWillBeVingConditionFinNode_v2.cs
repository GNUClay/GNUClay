using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeVingConditionFinNodeAction(ATNConditionSubjWillBeVingConditionFinNode_v2 item);

    public class ATNConditionSubjWillBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeVingConditionFinNodeFactory_v2(ATNConditionSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeVingConditionFinNodeFactory_v2(ATNConditionSubjWillBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingConditionFinNode_v2 sameNode, InitATNConditionSubjWillBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Ving_Condition_Fin;

        public ATNConditionSubjWillBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeVingConditionFinNodeAction mInitAction;

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

