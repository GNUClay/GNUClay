using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbBeObjConditionFinNodeAction(ATNConditionThereModalVerbBeObjConditionFinNode_v2 item);

    public class ATNConditionThereModalVerbBeObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbBeObjConditionFinNodeFactory_v2(ATNConditionThereModalVerbBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbBeObjConditionFinNodeFactory_v2(ATNConditionThereModalVerbBeObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbBeObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereModalVerbBeObjTransOrFinNode_v2 mParentNode;
        private ATNConditionThereModalVerbBeObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbBeObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbBeObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbBeObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionThereModalVerbBeObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbBeObjConditionFinNode_v2 sameNode, InitATNConditionThereModalVerbBeObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Be_Obj_Condition_Fin;

        public ATNConditionThereModalVerbBeObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbBeObjConditionFinNode_v2 mSameNode;
        private InitATNConditionThereModalVerbBeObjConditionFinNodeAction mInitAction;

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

