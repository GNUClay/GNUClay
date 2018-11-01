using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToBeSubjConditionVingObjConditionFinNodeAction(ATNFToBeSubjConditionVingObjConditionFinNode_v2 item);

    public class ATNFToBeSubjConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToBeSubjConditionVingObjConditionFinNodeFactory_v2(ATNFToBeSubjConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToBeSubjConditionVingObjConditionFinNodeFactory_v2(ATNFToBeSubjConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToBeSubjConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToBeSubjConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNFToBeSubjConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToBeSubjConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToBeSubjConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToBeSubjConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToBeSubjConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToBeSubjConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToBeSubjConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToBeSubjConditionVingObjConditionFinNode_v2 sameNode, InitATNFToBeSubjConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToBe_Subj_Condition_Ving_Obj_Condition_Fin;

        public ATNFToBeSubjConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToBeSubjConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNFToBeSubjConditionVingObjConditionFinNodeAction mInitAction;

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

