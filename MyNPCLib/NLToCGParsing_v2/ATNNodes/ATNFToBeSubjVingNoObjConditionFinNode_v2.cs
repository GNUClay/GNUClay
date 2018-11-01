using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjVingNoObjConditionFinNodeAction(ATNFToBeSubjVingNoObjConditionFinNode_v2 item);

    public class ATNFToBeSubjVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjVingNoObjConditionFinNodeFactory_v2(ATNFToBeSubjVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjVingNoObjConditionFinNodeFactory_v2(ATNFToBeSubjVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingNoObjConditionFinNode_v2 sameNode, InitATNFToBeSubjVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Ving_No_Obj_Condition_Fin;

        public ATNFToBeSubjVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjVingNoObjConditionFinNodeAction mInitAction;

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

