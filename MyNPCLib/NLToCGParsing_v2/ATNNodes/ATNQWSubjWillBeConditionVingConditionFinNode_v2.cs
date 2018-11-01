using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeConditionVingConditionFinNodeAction(ATNQWSubjWillBeConditionVingConditionFinNode_v2 item);

    public class ATNQWSubjWillBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeConditionVingConditionFinNodeFactory_v2(ATNQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeConditionVingConditionFinNodeFactory_v2(ATNQWSubjWillBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingConditionFinNode_v2 sameNode, InitATNQWSubjWillBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Condition_Ving_Condition_Fin;

        public ATNQWSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeConditionVingConditionFinNodeAction mInitAction;

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

