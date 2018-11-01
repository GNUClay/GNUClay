using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotConditionVingConditionFinNodeAction(ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeNotConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotConditionVingConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotConditionVingConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeNotConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Condition_Ving_Condition_Fin;

        public ATNConditionSubjFToBeNotConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotConditionVingConditionFinNodeAction mInitAction;

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

