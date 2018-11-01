using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToHaveBeenConditionVingConditionFinNodeAction(ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2 item);

    public class ATNQWSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToHaveBeenConditionVingConditionFinNodeFactory_v2(ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToHaveBeenConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToHaveBeenConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2 sameNode, InitATNQWSubjFToHaveBeenConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToHave_Been_Condition_Ving_Condition_Fin;

        public ATNQWSubjFToHaveBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToHaveBeenConditionVingConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToHaveBeenConditionVingConditionFinNodeAction mInitAction;

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

