using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenV3ConditionFinNodeAction(ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenV3ConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenV3ConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_V3_Condition_Fin;

        public ATNQWSubjWillFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenV3ConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenV3ConditionFinNodeAction mInitAction;

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

