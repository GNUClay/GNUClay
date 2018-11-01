using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeV3ObjConditionFinNodeAction(ATNConditionWillSubjBeV3ObjConditionFinNode_v2 item);

    public class ATNConditionWillSubjBeV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeV3ObjConditionFinNodeFactory_v2(ATNConditionWillSubjBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeV3ObjConditionFinNodeFactory_v2(ATNConditionWillSubjBeV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionWillSubjBeV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionWillSubjBeV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeV3ObjConditionFinNode_v2 sameNode, InitATNConditionWillSubjBeV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_V3_Obj_Condition_Fin;

        public ATNConditionWillSubjBeV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionWillSubjBeV3ObjConditionFinNodeAction mInitAction;

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

