using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveNotBeenVingConditionFinNodeAction(ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2 item);

    public class ATNConditionSubjFToHaveNotBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveNotBeenVingConditionFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveNotBeenVingConditionFinNodeFactory_v2(ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveNotBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveNotBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveNotBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2 sameNode, InitATNConditionSubjFToHaveNotBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Not_Been_Ving_Condition_Fin;

        public ATNConditionSubjFToHaveNotBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveNotBeenVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveNotBeenVingConditionFinNodeAction mInitAction;

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

