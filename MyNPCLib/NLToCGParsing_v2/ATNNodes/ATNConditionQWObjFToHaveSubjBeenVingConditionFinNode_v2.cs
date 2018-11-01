using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjBeenVingConditionFinNodeAction(ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjBeenVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenVingConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjBeenVingConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjBeenVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjBeenVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjBeenVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjBeenVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Been_Ving_Condition_Fin;

        public ATNConditionQWObjFToHaveSubjBeenVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjBeenVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjBeenVingConditionFinNodeAction mInitAction;

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

