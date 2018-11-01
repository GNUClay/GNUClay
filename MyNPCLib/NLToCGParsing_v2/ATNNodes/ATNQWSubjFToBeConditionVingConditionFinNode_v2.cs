using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeConditionVingConditionFinNodeAction(ATNQWSubjFToBeConditionVingConditionFinNode_v2 item);

    public class ATNQWSubjFToBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeConditionVingConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeConditionVingConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionVingConditionFinNode_v2 sameNode, InitATNQWSubjFToBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Condition_Ving_Condition_Fin;

        public ATNQWSubjFToBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeConditionVingConditionFinNodeAction mInitAction;

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

