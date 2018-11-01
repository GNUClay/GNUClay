using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeV3ConditionFinNodeAction(ATNConditionWillSubjBeV3ConditionFinNode_v2 item);

    public class ATNConditionWillSubjBeV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeV3ConditionFinNodeFactory_v2(ATNConditionWillSubjBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeV3ConditionFinNodeFactory_v2(ATNConditionWillSubjBeV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeV3TransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjBeV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeV3ConditionFinNode_v2 sameNode, InitATNConditionWillSubjBeV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_V3_Condition_Fin;

        public ATNConditionWillSubjBeV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeV3ConditionFinNodeAction mInitAction;

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

