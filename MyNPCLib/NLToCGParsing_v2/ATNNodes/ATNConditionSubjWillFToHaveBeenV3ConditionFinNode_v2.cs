using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenV3ConditionFinNodeAction(ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenV3ConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenV3ConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_V3_Condition_Fin;

        public ATNConditionSubjWillFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenV3ConditionFinNodeAction mInitAction;

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

