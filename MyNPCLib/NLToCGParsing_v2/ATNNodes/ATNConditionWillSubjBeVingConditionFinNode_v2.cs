using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeVingConditionFinNodeAction(ATNConditionWillSubjBeVingConditionFinNode_v2 item);

    public class ATNConditionWillSubjBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeVingConditionFinNodeFactory_v2(ATNConditionWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeVingConditionFinNodeFactory_v2(ATNConditionWillSubjBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingConditionFinNode_v2 sameNode, InitATNConditionWillSubjBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Ving_Condition_Fin;

        public ATNConditionWillSubjBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeVingConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeVingConditionFinNodeAction mInitAction;

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

