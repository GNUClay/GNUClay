using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbBeNoObjConditionFinNodeAction(ATNConditionThereModalVerbBeNoObjConditionFinNode_v2 item);

    public class ATNConditionThereModalVerbBeNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbBeNoObjConditionFinNodeFactory_v2(ATNConditionThereModalVerbBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbBeNoObjConditionFinNodeFactory_v2(ATNConditionThereModalVerbBeNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbBeNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereModalVerbBeNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionThereModalVerbBeNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbBeNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbBeNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbBeNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionThereModalVerbBeNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeNoObjConditionFinNode_v2 sameNode, InitATNConditionThereModalVerbBeNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Be_No_Obj_Condition_Fin;

        public ATNConditionThereModalVerbBeNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbBeNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionThereModalVerbBeNoObjConditionFinNodeAction mInitAction;

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

