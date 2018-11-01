using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotV3ConditionFinNodeAction(ATNConditionSubjFToBeNotV3ConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeNotV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotV3ConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotV3ConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeNotV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotV3ConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeNotV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_V3_Condition_Fin;

        public ATNConditionSubjFToBeNotV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotV3ConditionFinNodeAction mInitAction;

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

