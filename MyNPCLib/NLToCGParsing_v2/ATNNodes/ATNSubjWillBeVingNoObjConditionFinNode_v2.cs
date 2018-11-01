using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeVingNoObjConditionFinNodeAction(ATNSubjWillBeVingNoObjConditionFinNode_v2 item);

    public class ATNSubjWillBeVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeVingNoObjConditionFinNodeFactory_v2(ATNSubjWillBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeVingNoObjConditionFinNodeFactory_v2(ATNSubjWillBeVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillBeVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeVingNoObjConditionFinNode_v2 sameNode, InitATNSubjWillBeVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Ving_No_Obj_Condition_Fin;

        public ATNSubjWillBeVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillBeVingNoObjConditionFinNodeAction mInitAction;

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

