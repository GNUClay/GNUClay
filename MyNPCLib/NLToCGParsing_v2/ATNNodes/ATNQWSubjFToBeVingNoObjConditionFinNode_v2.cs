using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeVingNoObjConditionFinNodeAction(ATNQWSubjFToBeVingNoObjConditionFinNode_v2 item);

    public class ATNQWSubjFToBeVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeVingNoObjConditionFinNodeFactory_v2(ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeVingNoObjConditionFinNodeFactory_v2(ATNQWSubjFToBeVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeVingNoObjConditionFinNode_v2 sameNode, InitATNQWSubjFToBeVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Ving_No_Obj_Condition_Fin;

        public ATNQWSubjFToBeVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeVingNoObjConditionFinNodeAction mInitAction;

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

