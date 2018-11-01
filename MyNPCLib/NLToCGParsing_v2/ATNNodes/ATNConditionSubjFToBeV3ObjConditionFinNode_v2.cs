using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjFToBeV3ObjConditionFinNodeAction(ATNConditionSubjFToBeV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjFToBeV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjFToBeV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjFToBeV3ObjConditionFinNodeFactory_v2(ATNConditionSubjFToBeV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjFToBeV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjFToBeV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjFToBeV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjFToBeV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjFToBeV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjFToBeV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjFToBeV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjFToBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjFToBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjFToBeV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjFToBeV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_FToBe_V3_Obj_Condition_Fin;

        public ATNConditionSubjFToBeV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjFToBeV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjFToBeV3ObjConditionFinNodeAction mInitAction;

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

