using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereFToBeNoObjConditionFinNodeAction(ATNThereFToBeNoObjConditionFinNode_v2 item);

    public class ATNThereFToBeNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereFToBeNoObjConditionFinNodeFactory_v2(ATNThereFToBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereFToBeNoObjConditionFinNodeFactory_v2(ATNThereFToBeNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereFToBeNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereFToBeNoObjTransOrFinNode_v2 mParentNode;
        private ATNThereFToBeNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereFToBeNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereFToBeNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereFToBeNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNThereFToBeNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNThereFToBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereFToBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeNoObjConditionFinNode_v2 sameNode, InitATNThereFToBeNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_FToBe_No_Obj_Condition_Fin;

        public ATNThereFToBeNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNThereFToBeNoObjConditionFinNode_v2 mSameNode;
        private InitATNThereFToBeNoObjConditionFinNodeAction mInitAction;

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

