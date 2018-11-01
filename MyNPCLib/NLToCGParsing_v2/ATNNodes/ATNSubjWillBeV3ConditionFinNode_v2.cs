using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeV3ConditionFinNodeAction(ATNSubjWillBeV3ConditionFinNode_v2 item);

    public class ATNSubjWillBeV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeV3ConditionFinNodeFactory_v2(ATNSubjWillBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeV3ConditionFinNodeFactory_v2(ATNSubjWillBeV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillBeV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeV3ConditionFinNode_v2 sameNode, InitATNSubjWillBeV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_V3_Condition_Fin;

        public ATNSubjWillBeV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjWillBeV3ConditionFinNodeAction mInitAction;

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

