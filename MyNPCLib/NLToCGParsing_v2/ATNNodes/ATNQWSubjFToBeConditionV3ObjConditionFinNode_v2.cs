using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeConditionV3ObjConditionFinNodeAction(ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2 item);

    public class ATNQWSubjFToBeConditionV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeConditionV3ObjConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeConditionV3ObjConditionFinNodeFactory_v2(ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeConditionV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeConditionV3ObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeConditionV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2 sameNode, InitATNQWSubjFToBeConditionV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_Condition_V3_Obj_Condition_Fin;

        public ATNQWSubjFToBeConditionV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeConditionV3ObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeConditionV3ObjConditionFinNodeAction mInitAction;

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

