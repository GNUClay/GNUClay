using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNodeAction(ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2 item);

    public class ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNodeFactory_v2(ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWObjFToHaveSubjBeenConditionVingTransOrFinNode_v2 mParentNode;
        private ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenConditionVingTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2 sameNode, InitATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWObj_FToHave_Subj_Been_Condition_Ving_Condition_Fin;

        public ATNConditionQWObjFToHaveSubjBeenConditionVingTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNode_v2 mSameNode;
        private InitATNConditionQWObjFToHaveSubjBeenConditionVingConditionFinNodeAction mInitAction;

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

