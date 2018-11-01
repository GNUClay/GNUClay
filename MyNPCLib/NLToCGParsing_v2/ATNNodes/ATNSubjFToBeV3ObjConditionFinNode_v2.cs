using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjFToBeV3ObjConditionFinNodeAction(ATNSubjFToBeV3ObjConditionFinNode_v2 item);

    public class ATNSubjFToBeV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjFToBeV3ObjConditionFinNodeFactory_v2(ATNSubjFToBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjFToBeV3ObjConditionFinNodeFactory_v2(ATNSubjFToBeV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjFToBeV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjFToBeV3ObjTransOrFinNode_v2 mParentNode;
        private ATNSubjFToBeV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjFToBeV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjFToBeV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjFToBeV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjFToBeV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjFToBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjFToBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjFToBeV3ObjConditionFinNode_v2 sameNode, InitATNSubjFToBeV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_FToBe_V3_Obj_Condition_Fin;

        public ATNSubjFToBeV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjFToBeV3ObjConditionFinNode_v2 mSameNode;
        private InitATNSubjFToBeV3ObjConditionFinNodeAction mInitAction;

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

