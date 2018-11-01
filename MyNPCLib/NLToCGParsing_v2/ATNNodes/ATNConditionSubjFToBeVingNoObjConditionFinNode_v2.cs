using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeVingNoObjConditionFinNodeAction(ATNConditionSubjFToBeVingNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeVingNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Ving_No_Obj_Condition_Fin;

        public ATNConditionSubjFToBeVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeVingNoObjConditionFinNodeAction mInitAction;

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

