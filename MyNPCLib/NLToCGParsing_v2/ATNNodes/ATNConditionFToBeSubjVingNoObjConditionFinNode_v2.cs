using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToBeSubjVingNoObjConditionFinNodeAction(ATNConditionFToBeSubjVingNoObjConditionFinNode_v2 item);

    public class ATNConditionFToBeSubjVingNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToBeSubjVingNoObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToBeSubjVingNoObjConditionFinNodeFactory_v2(ATNConditionFToBeSubjVingNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToBeSubjVingNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionFToBeSubjVingNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToBeSubjVingNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToBeSubjVingNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToBeSubjVingNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionFToBeSubjVingNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToBeSubjVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToBeSubjVingNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToBeSubjVingNoObjConditionFinNode_v2 sameNode, InitATNConditionFToBeSubjVingNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToBe_Subj_Ving_No_Obj_Condition_Fin;

        public ATNConditionFToBeSubjVingNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToBeSubjVingNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionFToBeSubjVingNoObjConditionFinNodeAction mInitAction;

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

