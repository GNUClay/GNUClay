using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeConditionVingConditionFinNodeAction(ATNSubjWillBeConditionVingConditionFinNode_v2 item);

    public class ATNSubjWillBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeConditionVingConditionFinNodeFactory_v2(ATNSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeConditionVingConditionFinNodeFactory_v2(ATNSubjWillBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingConditionFinNode_v2 sameNode, InitATNSubjWillBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Condition_Ving_Condition_Fin;

        public ATNSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNSubjWillBeConditionVingConditionFinNodeAction mInitAction;

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

