using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNodeAction(ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 item);

    public class ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNodeFactory_v2(ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 sameNode, InitATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_FToHave_Been_Condition_V3_Condition_Fin;

        public ATNConditionWillSubjFToHaveBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjFToHaveBeenConditionV3ConditionFinNodeAction mInitAction;

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

