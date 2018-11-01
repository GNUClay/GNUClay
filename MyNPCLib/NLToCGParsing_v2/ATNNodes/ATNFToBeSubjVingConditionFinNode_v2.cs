using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjVingConditionFinNodeAction(ATNFToBeSubjVingConditionFinNode_v2 item);

    public class ATNFToBeSubjVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjVingConditionFinNodeFactory_v2(ATNFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjVingConditionFinNodeFactory_v2(ATNFToBeSubjVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjVingTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingConditionFinNode_v2 sameNode, InitATNFToBeSubjVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Ving_Condition_Fin;

        public ATNFToBeSubjVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjVingConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjVingConditionFinNodeAction mInitAction;

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

