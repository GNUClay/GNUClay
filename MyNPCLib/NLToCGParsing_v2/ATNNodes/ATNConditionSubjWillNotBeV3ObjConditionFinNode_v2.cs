using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeV3ObjConditionFinNodeAction(ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotBeV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeV3ObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeV3ObjConditionFinNodeFactory_v2(ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotBeV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_V3_Obj_Condition_Fin;

        public ATNConditionSubjWillNotBeV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeV3ObjConditionFinNodeAction mInitAction;

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

