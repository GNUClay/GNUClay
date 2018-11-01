using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjVingConditionFinNodeAction(ATNConditionFToBeSubjVingConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjVingConditionFinNodeFactory_v2(ATNConditionFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjVingConditionFinNodeFactory_v2(ATNConditionFToBeSubjVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Ving_Condition_Fin;

        public ATNConditionFToBeSubjVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjVingConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjVingConditionFinNodeAction mInitAction;

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

