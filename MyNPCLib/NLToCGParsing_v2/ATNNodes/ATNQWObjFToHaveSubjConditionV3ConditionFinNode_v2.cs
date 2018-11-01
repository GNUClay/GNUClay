using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveSubjConditionV3ConditionFinNodeAction(ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2 item);

    public class ATNQWObjFToHaveSubjConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveSubjConditionV3ConditionFinNodeFactory_v2(ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveSubjConditionV3ConditionFinNodeFactory_v2(ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveSubjConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 mParentNode;
        private ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveSubjConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2 sameNode, InitATNQWObjFToHaveSubjConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Subj_Condition_V3_Condition_Fin;

        public ATNQWObjFToHaveSubjConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveSubjConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToHaveSubjConditionV3ConditionFinNodeAction mInitAction;

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

