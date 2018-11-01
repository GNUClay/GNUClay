using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeVingObjConditionFinNodeAction(ATNConditionQWSubjWillBeVingObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillBeVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeVingObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeVingObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillBeVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeVingObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillBeVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_Ving_Obj_Condition_Fin;

        public ATNConditionQWSubjWillBeVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeVingObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeVingObjConditionFinNodeAction mInitAction;

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

