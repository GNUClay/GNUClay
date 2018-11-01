using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbBeObjConditionFinNodeAction(ATNThereModalVerbBeObjConditionFinNode_v2 item);

    public class ATNThereModalVerbBeObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbBeObjConditionFinNodeFactory_v2(ATNThereModalVerbBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbBeObjConditionFinNodeFactory_v2(ATNThereModalVerbBeObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbBeObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereModalVerbBeObjTransOrFinNode_v2 mParentNode;
        private ATNThereModalVerbBeObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbBeObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbBeObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbBeObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNThereModalVerbBeObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbBeObjConditionFinNode_v2 sameNode, InitATNThereModalVerbBeObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Be_Obj_Condition_Fin;

        public ATNThereModalVerbBeObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbBeObjConditionFinNode_v2 mSameNode;
        private InitATNThereModalVerbBeObjConditionFinNodeAction mInitAction;

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

