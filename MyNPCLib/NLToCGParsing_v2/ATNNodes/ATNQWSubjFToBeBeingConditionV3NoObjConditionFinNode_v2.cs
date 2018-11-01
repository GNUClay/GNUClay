using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeBeingConditionV3NoObjConditionFinNodeAction(ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 item);

    public class ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2(ATNQWSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2(ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeBeingConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeBeingConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 sameNode, InitATNQWSubjFToBeBeingConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Being_Condition_V3_No_Obj_Condition_Fin;

        public ATNQWSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeBeingConditionV3NoObjConditionFinNodeAction mInitAction;

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

