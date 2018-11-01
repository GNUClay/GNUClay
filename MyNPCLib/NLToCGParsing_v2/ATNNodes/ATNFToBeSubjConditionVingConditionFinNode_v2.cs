using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionVingConditionFinNodeAction(ATNFToBeSubjConditionVingConditionFinNode_v2 item);

    public class ATNFToBeSubjConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionVingConditionFinNodeFactory_v2(ATNFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionVingConditionFinNodeFactory_v2(ATNFToBeSubjConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionVingTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingConditionFinNode_v2 sameNode, InitATNFToBeSubjConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_Ving_Condition_Fin;

        public ATNFToBeSubjConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionVingConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjConditionVingConditionFinNodeAction mInitAction;

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

