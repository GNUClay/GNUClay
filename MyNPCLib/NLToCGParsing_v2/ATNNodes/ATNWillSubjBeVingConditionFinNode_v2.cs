using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeVingConditionFinNodeAction(ATNWillSubjBeVingConditionFinNode_v2 item);

    public class ATNWillSubjBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeVingConditionFinNodeFactory_v2(ATNWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeVingConditionFinNodeFactory_v2(ATNWillSubjBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeVingTransOrFinNode_v2 mParentNode;
        private ATNWillSubjBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeVingConditionFinNode_v2 sameNode, InitATNWillSubjBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Ving_Condition_Fin;

        public ATNWillSubjBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeVingConditionFinNode_v2 mSameNode;
        private InitATNWillSubjBeVingConditionFinNodeAction mInitAction;

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

