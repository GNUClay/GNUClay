using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNFToHaveSubjBeenConditionVingObjConditionFinNodeAction(ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2 item);

    public class ATNFToHaveSubjBeenConditionVingObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNFToHaveSubjBeenConditionVingObjConditionFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNFToHaveSubjBeenConditionVingObjConditionFinNodeFactory_v2(ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNFToHaveSubjBeenConditionVingObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNFToHaveSubjBeenConditionVingObjTransOrFinNode_v2 mParentNode;
        private ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNFToHaveSubjBeenConditionVingObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2 sameNode, InitATNFToHaveSubjBeenConditionVingObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.FToHave_Subj_Been_Condition_Ving_Obj_Condition_Fin;

        public ATNFToHaveSubjBeenConditionVingObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNFToHaveSubjBeenConditionVingObjConditionFinNode_v2 mSameNode;
        private InitATNFToHaveSubjBeenConditionVingObjConditionFinNodeAction mInitAction;

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

