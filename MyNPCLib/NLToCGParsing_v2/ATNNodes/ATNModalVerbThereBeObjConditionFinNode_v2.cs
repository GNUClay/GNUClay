using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbThereBeObjConditionFinNodeAction(ATNModalVerbThereBeObjConditionFinNode_v2 item);

    public class ATNModalVerbThereBeObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbThereBeObjConditionFinNodeFactory_v2(ATNModalVerbThereBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbThereBeObjConditionFinNodeFactory_v2(ATNModalVerbThereBeObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbThereBeObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbThereBeObjTransOrFinNode_v2 mParentNode;
        private ATNModalVerbThereBeObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbThereBeObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbThereBeObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbThereBeObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNModalVerbThereBeObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbThereBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbThereBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbThereBeObjConditionFinNode_v2 sameNode, InitATNModalVerbThereBeObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_There_Be_Obj_Condition_Fin;

        public ATNModalVerbThereBeObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbThereBeObjConditionFinNode_v2 mSameNode;
        private InitATNModalVerbThereBeObjConditionFinNodeAction mInitAction;

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

