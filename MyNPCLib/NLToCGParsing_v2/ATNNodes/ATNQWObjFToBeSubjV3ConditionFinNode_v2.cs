using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjV3ConditionFinNodeAction(ATNQWObjFToBeSubjV3ConditionFinNode_v2 item);

    public class ATNQWObjFToBeSubjV3ConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjV3ConditionFinNodeFactory_v2(ATNQWObjFToBeSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjV3ConditionFinNodeFactory_v2(ATNQWObjFToBeSubjV3ConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjV3ConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjV3TransOrFinNode_v2 mParentNode;
        private ATNQWObjFToBeSubjV3ConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjV3ConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjV3ConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjV3ConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToBeSubjV3ConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjV3ConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjV3ConditionFinNode_v2 sameNode, InitATNQWObjFToBeSubjV3ConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_V3_Condition_Fin;

        public ATNQWObjFToBeSubjV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjV3ConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjV3ConditionFinNodeAction mInitAction;

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

