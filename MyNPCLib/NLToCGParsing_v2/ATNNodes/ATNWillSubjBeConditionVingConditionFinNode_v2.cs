using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNWillSubjBeConditionVingConditionFinNodeAction(ATNWillSubjBeConditionVingConditionFinNode_v2 item);

    public class ATNWillSubjBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNWillSubjBeConditionVingConditionFinNodeFactory_v2(ATNWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNWillSubjBeConditionVingConditionFinNodeFactory_v2(ATNWillSubjBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNWillSubjBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNWillSubjBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNWillSubjBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNWillSubjBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNWillSubjBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNWillSubjBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNWillSubjBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNWillSubjBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNWillSubjBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNWillSubjBeConditionVingConditionFinNode_v2 sameNode, InitATNWillSubjBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Will_Subj_Be_Condition_Ving_Condition_Fin;

        public ATNWillSubjBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNWillSubjBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNWillSubjBeConditionVingConditionFinNodeAction mInitAction;

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

