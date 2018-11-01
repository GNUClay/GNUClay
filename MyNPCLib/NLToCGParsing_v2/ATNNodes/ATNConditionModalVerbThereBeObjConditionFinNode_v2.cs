using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbThereBeObjConditionFinNodeAction(ATNConditionModalVerbThereBeObjConditionFinNode_v2 item);

    public class ATNConditionModalVerbThereBeObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbThereBeObjConditionFinNodeFactory_v2(ATNConditionModalVerbThereBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbThereBeObjConditionFinNodeFactory_v2(ATNConditionModalVerbThereBeObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbThereBeObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbThereBeObjTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbThereBeObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbThereBeObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbThereBeObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbThereBeObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionModalVerbThereBeObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbThereBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbThereBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbThereBeObjConditionFinNode_v2 sameNode, InitATNConditionModalVerbThereBeObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_There_Be_Obj_Condition_Fin;

        public ATNConditionModalVerbThereBeObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbThereBeObjConditionFinNode_v2 mSameNode;
        private InitATNConditionModalVerbThereBeObjConditionFinNodeAction mInitAction;

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

