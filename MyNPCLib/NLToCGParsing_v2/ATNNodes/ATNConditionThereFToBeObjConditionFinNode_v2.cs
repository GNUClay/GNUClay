using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionThereFToBeObjConditionFinNodeAction(ATNConditionThereFToBeObjConditionFinNode_v2 item);

    public class ATNConditionThereFToBeObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionThereFToBeObjConditionFinNodeFactory_v2(ATNConditionThereFToBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionThereFToBeObjConditionFinNodeFactory_v2(ATNConditionThereFToBeObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionThereFToBeObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionThereFToBeObjTransOrFinNode_v2 mParentNode;
        private ATNConditionThereFToBeObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionThereFToBeObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionThereFToBeObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionThereFToBeObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionThereFToBeObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionThereFToBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionThereFToBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionThereFToBeObjConditionFinNode_v2 sameNode, InitATNConditionThereFToBeObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_There_FToBe_Obj_Condition_Fin;

        public ATNConditionThereFToBeObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionThereFToBeObjConditionFinNode_v2 mSameNode;
        private InitATNConditionThereFToBeObjConditionFinNodeAction mInitAction;

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

