using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenConditionVingNoObjConditionFinNodeAction(ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2 item);

    public class ATNFToHaveSubjBeenConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenConditionVingNoObjConditionFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2 sameNode, InitATNFToHaveSubjBeenConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Condition_Ving_No_Obj_Condition_Fin;

        public ATNFToHaveSubjBeenConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenConditionVingNoObjConditionFinNodeAction mInitAction;

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

