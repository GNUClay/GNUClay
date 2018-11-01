using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenVingObjConditionFinNodeAction(ATNFToHaveSubjBeenVingObjConditionFinNode_v2 item);

    public class ATNFToHaveSubjBeenVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenVingObjConditionFinNodeFactory_v2(ATNFToHaveSubjBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenVingObjConditionFinNodeFactory_v2(ATNFToHaveSubjBeenVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenVingObjTransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjBeenVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToHaveSubjBeenVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenVingObjConditionFinNode_v2 sameNode, InitATNFToHaveSubjBeenVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Ving_Obj_Condition_Fin;

        public ATNFToHaveSubjBeenVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenVingObjConditionFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenVingObjConditionFinNodeAction mInitAction;

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

