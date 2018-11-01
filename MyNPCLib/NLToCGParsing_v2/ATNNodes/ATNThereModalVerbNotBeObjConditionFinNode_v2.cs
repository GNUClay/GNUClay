using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereModalVerbNotBeObjConditionFinNodeAction(ATNThereModalVerbNotBeObjConditionFinNode_v2 item);

    public class ATNThereModalVerbNotBeObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereModalVerbNotBeObjConditionFinNodeFactory_v2(ATNThereModalVerbNotBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereModalVerbNotBeObjConditionFinNodeFactory_v2(ATNThereModalVerbNotBeObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereModalVerbNotBeObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereModalVerbNotBeObjTransOrFinNode_v2 mParentNode;
        private ATNThereModalVerbNotBeObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereModalVerbNotBeObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereModalVerbNotBeObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereModalVerbNotBeObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNThereModalVerbNotBeObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNThereModalVerbNotBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbNotBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereModalVerbNotBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNThereModalVerbNotBeObjConditionFinNode_v2 sameNode, InitATNThereModalVerbNotBeObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_ModalVerb_Not_Be_Obj_Condition_Fin;

        public ATNThereModalVerbNotBeObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNThereModalVerbNotBeObjConditionFinNode_v2 mSameNode;
        private InitATNThereModalVerbNotBeObjConditionFinNodeAction mInitAction;

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

