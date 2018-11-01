using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToHaveNotConditionV3ObjConditionFinNodeAction(ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToHaveNotConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToHaveNotConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToHaveNotConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToHaveNotConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToHaveNotConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToHave_Not_Condition_V3_Obj_Condition_Fin;

        public ATNConditionSubjFToHaveNotConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToHaveNotConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToHaveNotConditionV3ObjConditionFinNodeAction mInitAction;

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

