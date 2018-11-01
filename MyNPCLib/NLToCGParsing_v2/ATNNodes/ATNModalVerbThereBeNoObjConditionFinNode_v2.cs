using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbThereBeNoObjConditionFinNodeAction(ATNModalVerbThereBeNoObjConditionFinNode_v2 item);

    public class ATNModalVerbThereBeNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbThereBeNoObjConditionFinNodeFactory_v2(ATNModalVerbThereBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbThereBeNoObjConditionFinNodeFactory_v2(ATNModalVerbThereBeNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbThereBeNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbThereBeNoObjTransOrFinNode_v2 mParentNode;
        private ATNModalVerbThereBeNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbThereBeNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbThereBeNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbThereBeNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNModalVerbThereBeNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbThereBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbThereBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeNoObjConditionFinNode_v2 sameNode, InitATNModalVerbThereBeNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_There_Be_No_Obj_Condition_Fin;

        public ATNModalVerbThereBeNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbThereBeNoObjConditionFinNode_v2 mSameNode;
        private InitATNModalVerbThereBeNoObjConditionFinNodeAction mInitAction;

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

