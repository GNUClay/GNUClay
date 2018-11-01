using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotVingConditionFinNodeAction(ATNSubjFToBeNotVingConditionFinNode_v2 item);

    public class ATNSubjFToBeNotVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotVingConditionFinNodeFactory_v2(ATNSubjFToBeNotVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotVingConditionFinNodeFactory_v2(ATNSubjFToBeNotVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotVingTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeNotVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeNotVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotVingConditionFinNode_v2 sameNode, InitATNSubjFToBeNotVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Ving_Condition_Fin;

        public ATNSubjFToBeNotVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotVingConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotVingConditionFinNodeAction mInitAction;

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

