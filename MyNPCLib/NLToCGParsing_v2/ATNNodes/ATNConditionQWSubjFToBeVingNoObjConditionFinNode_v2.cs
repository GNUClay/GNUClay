using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeVingNoObjConditionFinNodeAction(ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeVingNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeVingNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Ving_No_Obj_Condition_Fin;

        public ATNConditionQWSubjFToBeVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeVingNoObjConditionFinNodeAction mInitAction;

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

