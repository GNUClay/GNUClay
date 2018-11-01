using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveBeenVingConditionFinNodeAction(ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenVingConditionFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveBeenVingConditionFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Been_Ving_Condition_Fin;

        public ATNConditionSubjWillNotFToHaveBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveBeenVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveBeenVingConditionFinNodeAction mInitAction;

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

