using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeVingNoObjConditionFinNodeAction(ATNConditionSubjWillBeVingNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillBeVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeVingNoObjConditionFinNodeFactory_v2(ATNConditionSubjWillBeVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillBeVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeVingNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillBeVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Ving_No_Obj_Condition_Fin;

        public ATNConditionSubjWillBeVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeVingNoObjConditionFinNodeAction mInitAction;

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

