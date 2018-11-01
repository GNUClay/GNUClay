using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjWillSubjBeV3ConditionFinNodeAction(ATNQWObjWillSubjBeV3ConditionFinNode_v2 item);

    public class ATNQWObjWillSubjBeV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjWillSubjBeV3ConditionFinNodeFactory_v2(ATNQWObjWillSubjBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjWillSubjBeV3ConditionFinNodeFactory_v2(ATNQWObjWillSubjBeV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjWillSubjBeV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjWillSubjBeV3TransOrFinNode_v2 mParentNode;
        private ATNQWObjWillSubjBeV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjWillSubjBeV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjWillSubjBeV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjWillSubjBeV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjWillSubjBeV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjWillSubjBeV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjWillSubjBeV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjWillSubjBeV3ConditionFinNode_v2 sameNode, InitATNQWObjWillSubjBeV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_Will_Subj_Be_V3_Condition_Fin;

        public ATNQWObjWillSubjBeV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjWillSubjBeV3ConditionFinNode_v2 mSameNode;
        private InitATNQWObjWillSubjBeV3ConditionFinNodeAction mInitAction;

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

