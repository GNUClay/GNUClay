using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionV3ObjConditionFinNodeAction(ATNFToBeSubjConditionV3ObjConditionFinNode_v2 item);

    public class ATNFToBeSubjConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionV3ObjConditionFinNodeFactory_v2(ATNFToBeSubjConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionV3ObjConditionFinNodeFactory_v2(ATNFToBeSubjConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionV3ObjConditionFinNode_v2 sameNode, InitATNFToBeSubjConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_V3_Obj_Condition_Fin;

        public ATNFToBeSubjConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjConditionV3ObjConditionFinNodeAction mInitAction;

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

