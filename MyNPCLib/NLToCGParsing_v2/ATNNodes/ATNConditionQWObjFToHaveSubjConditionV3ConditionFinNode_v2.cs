using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjConditionV3ConditionFinNodeAction(ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Condition_V3_Condition_Fin;

        public ATNConditionQWObjFToHaveSubjConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjConditionV3ConditionFinNodeAction mInitAction;

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

