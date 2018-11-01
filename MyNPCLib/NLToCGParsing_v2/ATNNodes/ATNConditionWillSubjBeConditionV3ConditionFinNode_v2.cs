using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeConditionV3ConditionFinNodeAction(ATNConditionWillSubjBeConditionV3ConditionFinNode_v2 item);

    public class ATNConditionWillSubjBeConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeConditionV3ConditionFinNodeFactory_v2(ATNConditionWillSubjBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeConditionV3ConditionFinNodeFactory_v2(ATNConditionWillSubjBeConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjBeConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionV3ConditionFinNode_v2 sameNode, InitATNConditionWillSubjBeConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Condition_V3_Condition_Fin;

        public ATNConditionWillSubjBeConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeConditionV3ConditionFinNodeAction mInitAction;

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

