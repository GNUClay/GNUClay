using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenConditionVingConditionFinNodeAction(ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2 item);

    public class ATNConditionFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2 sameNode, InitATNConditionFToHaveSubjBeenConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Condition_Ving_Condition_Fin;

        public ATNConditionFToHaveSubjBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenConditionVingConditionFinNodeAction mInitAction;

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

