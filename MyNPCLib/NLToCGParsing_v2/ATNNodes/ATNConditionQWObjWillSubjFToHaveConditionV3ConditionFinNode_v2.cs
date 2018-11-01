using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNodeAction(ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2 item);

    public class ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNodeFactory_v2(ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2 sameNode, InitATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_Will_Subj_FToHave_Condition_V3_Condition_Fin;

        public ATNConditionQWObjWillSubjFToHaveConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjWillSubjFToHaveConditionV3ConditionFinNodeAction mInitAction;

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

