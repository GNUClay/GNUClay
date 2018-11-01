using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereModalVerbNotBeObjConditionFinNodeAction(ATNConditionThereModalVerbNotBeObjConditionFinNode_v2 item);

    public class ATNConditionThereModalVerbNotBeObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereModalVerbNotBeObjConditionFinNodeFactory_v2(ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereModalVerbNotBeObjConditionFinNodeFactory_v2(ATNConditionThereModalVerbNotBeObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereModalVerbNotBeObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 mParentNode;
        private ATNConditionThereModalVerbNotBeObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereModalVerbNotBeObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereModalVerbNotBeObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereModalVerbNotBeObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionThereModalVerbNotBeObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereModalVerbNotBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereModalVerbNotBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereModalVerbNotBeObjConditionFinNode_v2 sameNode, InitATNConditionThereModalVerbNotBeObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_ModalVerb_Not_Be_Obj_Condition_Fin;

        public ATNConditionThereModalVerbNotBeObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionThereModalVerbNotBeObjConditionFinNode_v2 mSameNode;
        private InitATNConditionThereModalVerbNotBeObjConditionFinNodeAction mInitAction;

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

