using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToBeSubjVingConditionFinNodeAction(ATNQWObjFToBeSubjVingConditionFinNode_v2 item);

    public class ATNQWObjFToBeSubjVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToBeSubjVingConditionFinNodeFactory_v2(ATNQWObjFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToBeSubjVingConditionFinNodeFactory_v2(ATNQWObjFToBeSubjVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToBeSubjVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToBeSubjVingTransOrFinNode_v2 mParentNode;
        private ATNQWObjFToBeSubjVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToBeSubjVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToBeSubjVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToBeSubjVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToBeSubjVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToBeSubjVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToBeSubjVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToBeSubjVingConditionFinNode_v2 sameNode, InitATNQWObjFToBeSubjVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToBe_Subj_Ving_Condition_Fin;

        public ATNQWObjFToBeSubjVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToBeSubjVingConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToBeSubjVingConditionFinNodeAction mInitAction;

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

