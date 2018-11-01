using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNodeAction(ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Being_Condition_V3_Obj_Condition_Fin;

        public ATNConditionQWSubjFToBeBeingConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeBeingConditionV3ObjConditionFinNodeAction mInitAction;

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

