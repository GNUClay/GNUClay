using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillFToHaveBeenVingConditionFinNodeAction(ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2 item);

    public class ATNQWSubjWillFToHaveBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillFToHaveBeenVingConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillFToHaveBeenVingConditionFinNodeFactory_v2(ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillFToHaveBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillFToHaveBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2 sameNode, InitATNQWSubjWillFToHaveBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_FToHave_Been_Ving_Condition_Fin;

        public ATNQWSubjWillFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillFToHaveBeenVingConditionFinNodeAction mInitAction;

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

