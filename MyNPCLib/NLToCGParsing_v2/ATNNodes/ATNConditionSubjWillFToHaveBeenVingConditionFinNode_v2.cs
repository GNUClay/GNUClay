using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenVingConditionFinNodeAction(ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenVingConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenVingConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Ving_Condition_Fin;

        public ATNConditionSubjWillFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenVingConditionFinNodeAction mInitAction;

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

