using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeVingNoObjConditionFinNodeAction(ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillBeVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeVingNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeVingNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillBeVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Ving_No_Obj_Condition_Fin;

        public ATNConditionQWSubjWillBeVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeVingNoObjConditionFinNodeAction mInitAction;

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

