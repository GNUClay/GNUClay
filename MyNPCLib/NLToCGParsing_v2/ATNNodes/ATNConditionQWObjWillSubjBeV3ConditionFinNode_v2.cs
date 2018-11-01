using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjBeV3ConditionFinNodeAction(ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjWillSubjBeV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjBeV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjBeV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjBeV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjBeV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjWillSubjBeV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_Be_V3_Condition_Fin;

        public ATNConditionQWObjWillSubjBeV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjBeV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjBeV3ConditionFinNodeAction mInitAction;

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

