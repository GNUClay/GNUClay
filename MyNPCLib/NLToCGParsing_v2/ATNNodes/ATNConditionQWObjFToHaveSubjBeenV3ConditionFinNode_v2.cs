using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjBeenV3ConditionFinNodeAction(ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjBeenV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjBeenV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjBeenV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjBeenV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Been_V3_Condition_Fin;

        public ATNConditionQWObjFToHaveSubjBeenV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjBeenV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjBeenV3ConditionFinNodeAction mInitAction;

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

