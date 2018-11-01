using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeBeingConditionV3NoObjConditionFinNodeAction(ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 item);

    public class ATNSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2(ATNSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2(ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeBeingConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeBeingConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 sameNode, InitATNSubjFToBeBeingConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Being_Condition_V3_No_Obj_Condition_Fin;

        public ATNSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeBeingConditionV3NoObjConditionFinNodeAction mInitAction;

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

