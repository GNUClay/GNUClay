using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjConditionV3ConditionFinNodeAction(ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2 item);

    public class ATNQWObjFToBeSubjConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjConditionV3ConditionFinNodeFactory_v2(ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjConditionV3ConditionFinNodeFactory_v2(ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 mParentNode;
        private ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2 sameNode, InitATNQWObjFToBeSubjConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Condition_V3_Condition_Fin;

        public ATNQWObjFToBeSubjConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjConditionV3ConditionFinNodeAction mInitAction;

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

