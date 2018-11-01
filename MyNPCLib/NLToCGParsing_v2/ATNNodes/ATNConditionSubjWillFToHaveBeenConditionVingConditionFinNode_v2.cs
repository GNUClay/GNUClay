using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenConditionVingConditionFinNodeAction(ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Condition_Ving_Condition_Fin;

        public ATNConditionSubjWillFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenConditionVingConditionFinNodeAction mInitAction;

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

