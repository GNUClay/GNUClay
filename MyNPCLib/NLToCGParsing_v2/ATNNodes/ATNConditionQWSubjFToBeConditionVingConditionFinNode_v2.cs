using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionVingConditionFinNodeAction(ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionVingConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionVingConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_Ving_Condition_Fin;

        public ATNConditionQWSubjFToBeConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionVingConditionFinNodeAction mInitAction;

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

