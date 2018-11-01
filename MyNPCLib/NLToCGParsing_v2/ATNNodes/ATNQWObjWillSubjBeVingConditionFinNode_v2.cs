using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjBeVingConditionFinNodeAction(ATNQWObjWillSubjBeVingConditionFinNode_v2 item);

    public class ATNQWObjWillSubjBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjBeVingConditionFinNodeFactory_v2(ATNQWObjWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjBeVingConditionFinNodeFactory_v2(ATNQWObjWillSubjBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjBeVingTransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeVingConditionFinNode_v2 sameNode, InitATNQWObjWillSubjBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Be_Ving_Condition_Fin;

        public ATNQWObjWillSubjBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjBeVingConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjBeVingConditionFinNodeAction mInitAction;

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

