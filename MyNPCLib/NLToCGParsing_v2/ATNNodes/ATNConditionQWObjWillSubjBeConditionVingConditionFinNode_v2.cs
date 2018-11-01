using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjBeConditionVingConditionFinNodeAction(ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2 item);

    public class ATNConditionQWObjWillSubjBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjBeConditionVingConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjBeConditionVingConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2 sameNode, InitATNConditionQWObjWillSubjBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Be_Condition_Ving_Condition_Fin;

        public ATNConditionQWObjWillSubjBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjBeConditionVingConditionFinNodeAction mInitAction;

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

