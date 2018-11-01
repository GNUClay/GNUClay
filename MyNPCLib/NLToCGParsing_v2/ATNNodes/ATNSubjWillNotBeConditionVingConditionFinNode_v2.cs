using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeConditionVingConditionFinNodeAction(ATNSubjWillNotBeConditionVingConditionFinNode_v2 item);

    public class ATNSubjWillNotBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeConditionVingConditionFinNodeFactory_v2(ATNSubjWillNotBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeConditionVingConditionFinNodeFactory_v2(ATNSubjWillNotBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeConditionVingConditionFinNode_v2 sameNode, InitATNSubjWillNotBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_Condition_Ving_Condition_Fin;

        public ATNSubjWillNotBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotBeConditionVingConditionFinNodeAction mInitAction;

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

