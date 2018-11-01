using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjFToHaveV3ConditionFinNodeAction(ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjWillSubjFToHaveV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjFToHaveV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjFToHaveV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjFToHaveV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjFToHaveV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjFToHaveV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjWillSubjFToHaveV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_FToHave_V3_Condition_Fin;

        public ATNConditionQWObjWillSubjFToHaveV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjFToHaveV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjFToHaveV3ConditionFinNodeAction mInitAction;

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

