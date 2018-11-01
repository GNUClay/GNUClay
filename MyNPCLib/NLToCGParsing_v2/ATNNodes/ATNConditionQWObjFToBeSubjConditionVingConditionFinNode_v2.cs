using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjConditionVingConditionFinNodeAction(ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2 item);

    public class ATNConditionQWObjFToBeSubjConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjConditionVingConditionFinNodeFactory_v2(ATNConditionQWObjFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjConditionVingConditionFinNodeFactory_v2(ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2 sameNode, InitATNConditionQWObjFToBeSubjConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Condition_Ving_Condition_Fin;

        public ATNConditionQWObjFToBeSubjConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjConditionVingConditionFinNodeAction mInitAction;

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

