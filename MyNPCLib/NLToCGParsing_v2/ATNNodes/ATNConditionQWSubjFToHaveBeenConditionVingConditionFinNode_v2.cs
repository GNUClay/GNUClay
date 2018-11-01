using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveBeenConditionVingConditionFinNodeAction(ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2(ATNConditionQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2(ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveBeenConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveBeenConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToHaveBeenConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Been_Condition_Ving_Condition_Fin;

        public ATNConditionQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveBeenConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveBeenConditionVingConditionFinNodeAction mInitAction;

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

