using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjBeingConditionV3ConditionFinNodeAction(ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2 item);

    public class ATNQWObjFToBeSubjBeingConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjBeingConditionV3ConditionFinNodeFactory_v2(ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjBeingConditionV3ConditionFinNodeFactory_v2(ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjBeingConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 mParentNode;
        private ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjBeingConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2 sameNode, InitATNQWObjFToBeSubjBeingConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Being_Condition_V3_Condition_Fin;

        public ATNQWObjFToBeSubjBeingConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjBeingConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjBeingConditionV3ConditionFinNodeAction mInitAction;

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

