using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillBeConditionVingNoObjConditionFinNodeAction(ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2 item);

    public class ATNQWSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2(ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillBeConditionVingNoObjConditionFinNodeFactory_v2(ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillBeConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillBeConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2 sameNode, InitATNQWSubjWillBeConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Be_Condition_Ving_No_Obj_Condition_Fin;

        public ATNQWSubjWillBeConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillBeConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillBeConditionVingNoObjConditionFinNodeAction mInitAction;

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

