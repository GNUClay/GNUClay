using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveBeenVingConditionFinNodeAction(ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToHaveBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveBeenVingConditionFinNodeFactory_v2(ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveBeenVingConditionFinNodeFactory_v2(ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToHaveBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Been_Ving_Condition_Fin;

        public ATNConditionQWSubjFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveBeenVingConditionFinNodeAction mInitAction;

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

