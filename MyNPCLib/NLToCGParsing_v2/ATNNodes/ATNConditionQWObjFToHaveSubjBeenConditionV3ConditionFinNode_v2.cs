using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNodeAction(ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Been_Condition_V3_Condition_Fin;

        public ATNConditionQWObjFToHaveSubjBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjBeenConditionV3ConditionFinNodeAction mInitAction;

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

