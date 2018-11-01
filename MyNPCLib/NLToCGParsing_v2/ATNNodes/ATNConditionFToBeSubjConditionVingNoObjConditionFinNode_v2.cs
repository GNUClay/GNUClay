using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjConditionVingNoObjConditionFinNodeAction(ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjConditionVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjConditionVingNoObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjConditionVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjConditionVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjConditionVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Condition_Ving_No_Obj_Condition_Fin;

        public ATNConditionFToBeSubjConditionVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjConditionVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjConditionVingNoObjConditionFinNodeAction mInitAction;

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

