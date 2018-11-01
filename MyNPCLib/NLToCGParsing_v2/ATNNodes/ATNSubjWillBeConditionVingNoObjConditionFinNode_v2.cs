using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeConditionVingNoObjConditionFinNodeAction(ATNSubjWillBeConditionVingNoObjConditionFinNode_v2 item);

    public class ATNSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2(ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2(ATNSubjWillBeConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillBeConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeConditionVingNoObjConditionFinNode_v2 sameNode, InitATNSubjWillBeConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_Condition_Ving_No_Obj_Condition_Fin;

        public ATNSubjWillBeConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillBeConditionVingNoObjConditionFinNodeAction mInitAction;

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

