using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjConditionV3ConditionFinNodeAction(ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjFToBeSubjConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjFToBeSubjConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Condition_V3_Condition_Fin;

        public ATNConditionQWObjFToBeSubjConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjConditionV3ConditionFinNodeAction mInitAction;

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

