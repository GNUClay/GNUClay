using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeConditionVingConditionFinNodeAction(ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeConditionVingConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeConditionVingConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Condition_Ving_Condition_Fin;

        public ATNConditionQWSubjWillBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeConditionVingConditionFinNodeAction mInitAction;

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

