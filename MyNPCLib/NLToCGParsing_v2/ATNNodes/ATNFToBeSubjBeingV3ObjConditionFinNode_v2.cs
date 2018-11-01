using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjBeingV3ObjConditionFinNodeAction(ATNFToBeSubjBeingV3ObjConditionFinNode_v2 item);

    public class ATNFToBeSubjBeingV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjBeingV3ObjConditionFinNodeFactory_v2(ATNFToBeSubjBeingV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjBeingV3ObjConditionFinNodeFactory_v2(ATNFToBeSubjBeingV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjBeingV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjBeingV3ObjTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjBeingV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjBeingV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjBeingV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjBeingV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjBeingV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjBeingV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjBeingV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjBeingV3ObjConditionFinNode_v2 sameNode, InitATNFToBeSubjBeingV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Being_V3_Obj_Condition_Fin;

        public ATNFToBeSubjBeingV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjBeingV3ObjConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjBeingV3ObjConditionFinNodeAction mInitAction;

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

