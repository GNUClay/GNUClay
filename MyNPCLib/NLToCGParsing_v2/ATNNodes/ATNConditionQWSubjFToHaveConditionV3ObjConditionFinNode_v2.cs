using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToHaveConditionV3ObjConditionFinNodeAction(ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToHaveConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToHaveConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToHaveConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToHaveConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToHaveConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToHave_Condition_V3_Obj_Condition_Fin;

        public ATNConditionQWSubjFToHaveConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToHaveConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToHaveConditionV3ObjConditionFinNodeAction mInitAction;

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

