using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToHaveNotBeenConditionVingConditionFinNodeAction(ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2 item);

    public class ATNSubjFToHaveNotBeenConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToHaveNotBeenConditionVingConditionFinNodeFactory_v2(ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToHaveNotBeenConditionVingConditionFinNodeFactory_v2(ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToHaveNotBeenConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToHaveNotBeenConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2 sameNode, InitATNSubjFToHaveNotBeenConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToHave_Not_Been_Condition_Ving_Condition_Fin;

        public ATNSubjFToHaveNotBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToHaveNotBeenConditionVingConditionFinNode_v2 mSameNode;
        private InitATNSubjFToHaveNotBeenConditionVingConditionFinNodeAction mInitAction;

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

