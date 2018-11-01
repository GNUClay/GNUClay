using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeVingConditionFinNodeAction(ATNConditionQWSubjWillBeVingConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeVingConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeVingConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeVingConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Ving_Condition_Fin;

        public ATNConditionQWSubjWillBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeVingConditionFinNodeAction mInitAction;

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

