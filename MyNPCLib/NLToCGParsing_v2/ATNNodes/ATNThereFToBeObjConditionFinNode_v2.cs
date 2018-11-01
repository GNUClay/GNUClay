using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNThereFToBeObjConditionFinNodeAction(ATNThereFToBeObjConditionFinNode_v2 item);

    public class ATNThereFToBeObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNThereFToBeObjConditionFinNodeFactory_v2(ATNThereFToBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNThereFToBeObjConditionFinNodeFactory_v2(ATNThereFToBeObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNThereFToBeObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNThereFToBeObjTransOrFinNode_v2 mParentNode;
        private ATNThereFToBeObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNThereFToBeObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNThereFToBeObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNThereFToBeObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNThereFToBeObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNThereFToBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNThereFToBeObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNThereFToBeObjConditionFinNode_v2 sameNode, InitATNThereFToBeObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.There_FToBe_Obj_Condition_Fin;

        public ATNThereFToBeObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNThereFToBeObjConditionFinNode_v2 mSameNode;
        private InitATNThereFToBeObjConditionFinNodeAction mInitAction;

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

