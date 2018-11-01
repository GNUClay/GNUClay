using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjBeingV3ConditionFinNodeAction(ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2 item);

    public class ATNQWObjFToBeSubjBeingV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjBeingV3ConditionFinNodeFactory_v2(ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjBeingV3ConditionFinNodeFactory_v2(ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjBeingV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 mParentNode;
        private ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjBeingV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2 sameNode, InitATNQWObjFToBeSubjBeingV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Being_V3_Condition_Fin;

        public ATNQWObjFToBeSubjBeingV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjBeingV3ConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjBeingV3ConditionFinNodeAction mInitAction;

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

