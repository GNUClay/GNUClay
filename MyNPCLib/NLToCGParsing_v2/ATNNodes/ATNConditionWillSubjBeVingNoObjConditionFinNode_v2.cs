using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeVingNoObjConditionFinNodeAction(ATNConditionWillSubjBeVingNoObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjBeVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeVingNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeVingNoObjConditionFinNodeFactory_v2(ATNConditionWillSubjBeVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjBeVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeVingNoObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjBeVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Ving_No_Obj_Condition_Fin;

        public ATNConditionWillSubjBeVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeVingNoObjConditionFinNodeAction mInitAction;

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

