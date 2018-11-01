using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNodeAction(ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Being_Condition_V3_No_Obj_Condition_Fin;

        public ATNConditionSubjFToBeBeingConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeBeingConditionV3NoObjConditionFinNodeAction mInitAction;

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

