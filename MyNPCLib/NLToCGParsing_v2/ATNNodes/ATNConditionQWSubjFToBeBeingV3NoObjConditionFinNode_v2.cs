using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeBeingV3NoObjConditionFinNodeAction(ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeBeingV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeBeingV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeBeingV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Being_V3_No_Obj_Condition_Fin;

        public ATNConditionQWSubjFToBeBeingV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeBeingV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeBeingV3NoObjConditionFinNodeAction mInitAction;

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

