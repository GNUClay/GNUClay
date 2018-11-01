using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenV3ConditionFinNodeAction(ATNQWSubjFToHaveBeenV3ConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenV3ConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenV3ConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenV3TransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveBeenV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenV3ConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_V3_Condition_Fin;

        public ATNQWSubjFToHaveBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenV3ConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenV3ConditionFinNodeAction mInitAction;

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

