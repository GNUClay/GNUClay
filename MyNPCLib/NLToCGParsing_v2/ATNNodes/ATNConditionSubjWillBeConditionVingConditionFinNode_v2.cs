using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeConditionVingConditionFinNodeAction(ATNConditionSubjWillBeConditionVingConditionFinNode_v2 item);

    public class ATNConditionSubjWillBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeConditionVingConditionFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeConditionVingConditionFinNodeFactory_v2(ATNConditionSubjWillBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionVingConditionFinNode_v2 sameNode, InitATNConditionSubjWillBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Condition_Ving_Condition_Fin;

        public ATNConditionSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeConditionVingConditionFinNodeAction mInitAction;

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

