using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeVingNoObjConditionFinNodeAction(ATNSubjFToBeVingNoObjConditionFinNode_v2 item);

    public class ATNSubjFToBeVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeVingNoObjConditionFinNodeFactory_v2(ATNSubjFToBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeVingNoObjConditionFinNodeFactory_v2(ATNSubjFToBeVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeVingNoObjConditionFinNode_v2 sameNode, InitATNSubjFToBeVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Ving_No_Obj_Condition_Fin;

        public ATNSubjFToBeVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeVingNoObjConditionFinNodeAction mInitAction;

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

