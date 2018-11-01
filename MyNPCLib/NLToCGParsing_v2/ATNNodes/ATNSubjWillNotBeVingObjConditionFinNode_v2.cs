using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotBeVingObjConditionFinNodeAction(ATNSubjWillNotBeVingObjConditionFinNode_v2 item);

    public class ATNSubjWillNotBeVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotBeVingObjConditionFinNodeFactory_v2(ATNSubjWillNotBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotBeVingObjConditionFinNodeFactory_v2(ATNSubjWillNotBeVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotBeVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotBeVingObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotBeVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotBeVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotBeVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotBeVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotBeVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotBeVingObjConditionFinNode_v2 sameNode, InitATNSubjWillNotBeVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Be_Ving_Obj_Condition_Fin;

        public ATNSubjWillNotBeVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotBeVingObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotBeVingObjConditionFinNodeAction mInitAction;

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

