using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjBeingV3ConditionFinNodeAction(ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjFToBeSubjBeingV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjBeingV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToBeSubjBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjBeingV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjBeingV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjBeingV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjBeingV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjFToBeSubjBeingV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Being_V3_Condition_Fin;

        public ATNConditionQWObjFToBeSubjBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjBeingV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjBeingV3ConditionFinNodeAction mInitAction;

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

