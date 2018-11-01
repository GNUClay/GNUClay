using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeNotConditionV3ObjConditionFinNodeAction(ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeNotConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeNotConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeNotConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeNotConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeNotConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeNotConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeNotConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_Not_Condition_V3_Obj_Condition_Fin;

        public ATNConditionSubjFToBeNotConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeNotConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeNotConditionV3ObjConditionFinNodeAction mInitAction;

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

