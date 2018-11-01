using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenConditionVingConditionFinNodeAction(ATNFToHaveSubjBeenConditionVingConditionFinNode_v2 item);

    public class ATNFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjBeenConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToHaveSubjBeenConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingConditionFinNode_v2 sameNode, InitATNFToHaveSubjBeenConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Condition_Ving_Condition_Fin;

        public ATNFToHaveSubjBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenConditionVingConditionFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenConditionVingConditionFinNodeAction mInitAction;

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

