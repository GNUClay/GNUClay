using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeNotConditionV3ObjConditionFinNodeAction(ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2 item);

    public class ATNSubjFToBeNotConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeNotConditionV3ObjConditionFinNodeFactory_v2(ATNSubjFToBeNotConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeNotConditionV3ObjConditionFinNodeFactory_v2(ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeNotConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeNotConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeNotConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2 sameNode, InitATNSubjFToBeNotConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_Not_Condition_V3_Obj_Condition_Fin;

        public ATNSubjFToBeNotConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeNotConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeNotConditionV3ObjConditionFinNodeAction mInitAction;

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

