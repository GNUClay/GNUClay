using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeVingObjConditionFinNodeAction(ATNConditionSubjWillNotBeVingObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotBeVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeVingObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeVingObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotBeVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotBeVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeVingObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotBeVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Ving_Obj_Condition_Fin;

        public ATNConditionSubjWillNotBeVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeVingObjConditionFinNodeAction mInitAction;

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

