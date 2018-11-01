using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotConditionVingObjConditionFinNodeAction(ATNSubjFToBeNotConditionVingObjConditionFinNode_v2 item);

    public class ATNSubjFToBeNotConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotConditionVingObjConditionFinNodeFactory_v2(ATNSubjFToBeNotConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotConditionVingObjConditionFinNodeFactory_v2(ATNSubjFToBeNotConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeNotConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeNotConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotConditionVingObjConditionFinNode_v2 sameNode, InitATNSubjFToBeNotConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Condition_Ving_Obj_Condition_Fin;

        public ATNSubjFToBeNotConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotConditionVingObjConditionFinNodeAction mInitAction;

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

