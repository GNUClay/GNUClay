using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjFToBeV3ObjConditionFinNodeAction(ATNQWSubjFToBeV3ObjConditionFinNode_v2 item);

    public class ATNQWSubjFToBeV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjFToBeV3ObjConditionFinNodeFactory_v2(ATNQWSubjFToBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjFToBeV3ObjConditionFinNodeFactory_v2(ATNQWSubjFToBeV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjFToBeV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjFToBeV3ObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjFToBeV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjFToBeV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjFToBeV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjFToBeV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjFToBeV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjFToBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjFToBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjFToBeV3ObjConditionFinNode_v2 sameNode, InitATNQWSubjFToBeV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_FToBe_V3_Obj_Condition_Fin;

        public ATNQWSubjFToBeV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjFToBeV3ObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjFToBeV3ObjConditionFinNodeAction mInitAction;

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

