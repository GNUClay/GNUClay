using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeVingConditionFinNodeAction(ATNConditionSubjWillNotBeVingConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeVingConditionFinNodeFactory_v2(ATNConditionSubjWillNotBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeVingConditionFinNodeFactory_v2(ATNConditionSubjWillNotBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeVingConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Ving_Condition_Fin;

        public ATNConditionSubjWillNotBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeVingConditionFinNodeAction mInitAction;

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

