using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjBeingConditionV3NoObjConditionFinNodeAction(ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2 item);

    public class ATNFToBeSubjBeingConditionV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjBeingConditionV3NoObjConditionFinNodeFactory_v2(ATNFToBeSubjBeingConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjBeingConditionV3NoObjConditionFinNodeFactory_v2(ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjBeingConditionV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjBeingConditionV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjBeingConditionV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingConditionV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2 sameNode, InitATNFToBeSubjBeingConditionV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Being_Condition_V3_No_Obj_Condition_Fin;

        public ATNFToBeSubjBeingConditionV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjBeingConditionV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjBeingConditionV3NoObjConditionFinNodeAction mInitAction;

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

