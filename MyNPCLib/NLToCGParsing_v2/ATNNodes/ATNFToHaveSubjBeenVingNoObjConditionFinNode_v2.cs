using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenVingNoObjConditionFinNodeAction(ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2 item);

    public class ATNFToHaveSubjBeenVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenVingNoObjConditionFinNodeFactory_v2(ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenVingNoObjConditionFinNodeFactory_v2(ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2 sameNode, InitATNFToHaveSubjBeenVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Ving_No_Obj_Condition_Fin;

        public ATNFToHaveSubjBeenVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenVingNoObjConditionFinNodeAction mInitAction;

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

