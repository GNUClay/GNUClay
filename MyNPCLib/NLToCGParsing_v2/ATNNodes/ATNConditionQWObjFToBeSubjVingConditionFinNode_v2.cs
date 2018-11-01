using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToBeSubjVingConditionFinNodeAction(ATNConditionQWObjFToBeSubjVingConditionFinNode_v2 item);

    public class ATNConditionQWObjFToBeSubjVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToBeSubjVingConditionFinNodeFactory_v2(ATNConditionQWObjFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToBeSubjVingConditionFinNodeFactory_v2(ATNConditionQWObjFToBeSubjVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToBeSubjVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToBeSubjVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToBeSubjVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToBeSubjVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToBeSubjVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToBeSubjVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToBeSubjVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToBeSubjVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToBeSubjVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToBeSubjVingConditionFinNode_v2 sameNode, InitATNConditionQWObjFToBeSubjVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToBe_Subj_Ving_Condition_Fin;

        public ATNConditionQWObjFToBeSubjVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToBeSubjVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToBeSubjVingConditionFinNodeAction mInitAction;

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

