using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjBeVingConditionFinNodeAction(ATNConditionQWObjWillSubjBeVingConditionFinNode_v2 item);

    public class ATNConditionQWObjWillSubjBeVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjBeVingConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjBeVingConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjBeVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjBeVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjBeVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjBeVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjBeVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjBeVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjWillSubjBeVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjBeVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeVingConditionFinNode_v2 sameNode, InitATNConditionQWObjWillSubjBeVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Be_Ving_Condition_Fin;

        public ATNConditionQWObjWillSubjBeVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjBeVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjBeVingConditionFinNodeAction mInitAction;

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

