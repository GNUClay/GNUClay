using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereFToBeNoObjConditionFinNodeAction(ATNConditionThereFToBeNoObjConditionFinNode_v2 item);

    public class ATNConditionThereFToBeNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereFToBeNoObjConditionFinNodeFactory_v2(ATNConditionThereFToBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereFToBeNoObjConditionFinNodeFactory_v2(ATNConditionThereFToBeNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereFToBeNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereFToBeNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionThereFToBeNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereFToBeNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereFToBeNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereFToBeNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionThereFToBeNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereFToBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereFToBeNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeNoObjConditionFinNode_v2 sameNode, InitATNConditionThereFToBeNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_FToBe_No_Obj_Condition_Fin;

        public ATNConditionThereFToBeNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionThereFToBeNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionThereFToBeNoObjConditionFinNodeAction mInitAction;

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

