using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotBeenConditionV3ConditionFinNodeAction(ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2 item);

    public class ATNSubjFToHaveNotBeenConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotBeenConditionV3ConditionFinNodeFactory_v2(ATNSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotBeenConditionV3ConditionFinNodeFactory_v2(ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotBeenConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotBeenConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2 sameNode, InitATNSubjFToHaveNotBeenConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Been_Condition_V3_Condition_Fin;

        public ATNSubjFToHaveNotBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotBeenConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotBeenConditionV3ConditionFinNodeAction mInitAction;

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

