using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjConditionVingConditionFinNodeAction(ATNConditionFToBeSubjConditionVingConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjConditionVingConditionFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjConditionVingConditionFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Condition_Ving_Condition_Fin;

        public ATNConditionFToBeSubjConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjConditionVingConditionFinNodeAction mInitAction;

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

