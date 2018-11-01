using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenVingConditionFinNodeAction(ATNFToHaveSubjBeenVingConditionFinNode_v2 item);

    public class ATNFToHaveSubjBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenVingConditionFinNodeFactory_v2(ATNFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenVingConditionFinNodeFactory_v2(ATNFToHaveSubjBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenVingTransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToHaveSubjBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenVingConditionFinNode_v2 sameNode, InitATNFToHaveSubjBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Ving_Condition_Fin;

        public ATNFToHaveSubjBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenVingConditionFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenVingConditionFinNodeAction mInitAction;

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

