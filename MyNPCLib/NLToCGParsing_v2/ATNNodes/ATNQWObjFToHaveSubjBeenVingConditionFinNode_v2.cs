using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjFToHaveSubjBeenVingConditionFinNodeAction(ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2 item);

    public class ATNQWObjFToHaveSubjBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjFToHaveSubjBeenVingConditionFinNodeFactory_v2(ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjFToHaveSubjBeenVingConditionFinNodeFactory_v2(ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjFToHaveSubjBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 mParentNode;
        private ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjFToHaveSubjBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2 sameNode, InitATNQWObjFToHaveSubjBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_FToHave_Subj_Been_Ving_Condition_Fin;

        public ATNQWObjFToHaveSubjBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjFToHaveSubjBeenVingConditionFinNode_v2 mSameNode;
        private InitATNQWObjFToHaveSubjBeenVingConditionFinNodeAction mInitAction;

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

