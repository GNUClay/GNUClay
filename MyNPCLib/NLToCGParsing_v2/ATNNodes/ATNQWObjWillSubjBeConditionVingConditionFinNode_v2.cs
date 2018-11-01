using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjBeConditionVingConditionFinNodeAction(ATNQWObjWillSubjBeConditionVingConditionFinNode_v2 item);

    public class ATNQWObjWillSubjBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjBeConditionVingConditionFinNodeFactory_v2(ATNQWObjWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjBeConditionVingConditionFinNodeFactory_v2(ATNQWObjWillSubjBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeConditionVingConditionFinNode_v2 sameNode, InitATNQWObjWillSubjBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Be_Condition_Ving_Condition_Fin;

        public ATNQWObjWillSubjBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjBeConditionVingConditionFinNodeAction mInitAction;

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

