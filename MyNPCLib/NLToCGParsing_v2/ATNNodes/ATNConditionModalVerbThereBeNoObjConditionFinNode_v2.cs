using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbThereBeNoObjConditionFinNodeAction(ATNConditionModalVerbThereBeNoObjConditionFinNode_v2 item);

    public class ATNConditionModalVerbThereBeNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbThereBeNoObjConditionFinNodeFactory_v2(ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbThereBeNoObjConditionFinNodeFactory_v2(ATNConditionModalVerbThereBeNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbThereBeNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbThereBeNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbThereBeNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbThereBeNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbThereBeNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionModalVerbThereBeNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbThereBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbThereBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeNoObjConditionFinNode_v2 sameNode, InitATNConditionModalVerbThereBeNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_There_Be_No_Obj_Condition_Fin;

        public ATNConditionModalVerbThereBeNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbThereBeNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionModalVerbThereBeNoObjConditionFinNodeAction mInitAction;

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

