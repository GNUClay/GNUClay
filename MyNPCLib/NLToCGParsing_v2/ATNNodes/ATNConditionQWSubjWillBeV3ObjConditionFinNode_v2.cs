using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjWillBeV3ObjConditionFinNodeAction(ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjWillBeV3ObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjWillBeV3ObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjWillBeV3ObjConditionFinNodeFactory_v2(ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjWillBeV3ObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjWillBeV3ObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjWillBeV3ObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeV3ObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjWillBeV3ObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Will_Be_V3_Obj_Condition_Fin;

        public ATNConditionQWSubjWillBeV3ObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjWillBeV3ObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjWillBeV3ObjConditionFinNodeAction mInitAction;

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

