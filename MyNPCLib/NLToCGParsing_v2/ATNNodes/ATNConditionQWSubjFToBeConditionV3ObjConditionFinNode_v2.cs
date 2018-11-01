using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjFToBeConditionV3ObjConditionFinNodeAction(ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjFToBeConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjFToBeConditionV3ObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjFToBeConditionV3ObjConditionFinNodeFactory_v2(ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjFToBeConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjFToBeConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjFToBeConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjFToBeConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_FToBe_Condition_V3_Obj_Condition_Fin;

        public ATNConditionQWSubjFToBeConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjFToBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjFToBeConditionV3ObjConditionFinNodeAction mInitAction;

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

