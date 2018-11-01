using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeConditionVingConditionFinNodeAction(ATNConditionWillSubjBeConditionVingConditionFinNode_v2 item);

    public class ATNConditionWillSubjBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeConditionVingConditionFinNodeFactory_v2(ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeConditionVingConditionFinNodeFactory_v2(ATNConditionWillSubjBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionVingConditionFinNode_v2 sameNode, InitATNConditionWillSubjBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Condition_Ving_Condition_Fin;

        public ATNConditionWillSubjBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeConditionVingConditionFinNodeAction mInitAction;

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

