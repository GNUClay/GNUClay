using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeConditionV3ConditionFinNodeAction(ATNSubjWillBeConditionV3ConditionFinNode_v2 item);

    public class ATNSubjWillBeConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeConditionV3ConditionFinNodeFactory_v2(ATNSubjWillBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeConditionV3ConditionFinNodeFactory_v2(ATNSubjWillBeConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillBeConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionV3ConditionFinNode_v2 sameNode, InitATNSubjWillBeConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Condition_V3_Condition_Fin;

        public ATNSubjWillBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjWillBeConditionV3ConditionFinNodeAction mInitAction;

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

