using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjVingObjConditionFinNodeAction(ATNFToBeSubjVingObjConditionFinNode_v2 item);

    public class ATNFToBeSubjVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjVingObjConditionFinNodeFactory_v2(ATNFToBeSubjVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjVingObjConditionFinNodeFactory_v2(ATNFToBeSubjVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjVingObjTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjVingObjConditionFinNode_v2 sameNode, InitATNFToBeSubjVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Ving_Obj_Condition_Fin;

        public ATNFToBeSubjVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjVingObjConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjVingObjConditionFinNodeAction mInitAction;

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

