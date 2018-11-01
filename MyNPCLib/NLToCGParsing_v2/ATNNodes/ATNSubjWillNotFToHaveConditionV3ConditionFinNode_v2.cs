using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveConditionV3ConditionFinNodeAction(ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2 item);

    public class ATNSubjWillNotFToHaveConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveConditionV3ConditionFinNodeFactory_v2(ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveConditionV3ConditionFinNodeFactory_v2(ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2 sameNode, InitATNSubjWillNotFToHaveConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Condition_V3_Condition_Fin;

        public ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveConditionV3ConditionFinNodeAction mInitAction;

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

