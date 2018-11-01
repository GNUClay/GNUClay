using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotVingConditionFinNodeAction(ATNConditionSubjFToBeNotVingConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeNotVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotVingConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotVingConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeNotVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotVingConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeNotVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Ving_Condition_Fin;

        public ATNConditionSubjFToBeNotVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotVingConditionFinNodeAction mInitAction;

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

