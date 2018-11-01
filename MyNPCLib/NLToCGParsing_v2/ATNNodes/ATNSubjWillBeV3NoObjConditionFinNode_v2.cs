using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillBeV3NoObjConditionFinNodeAction(ATNSubjWillBeV3NoObjConditionFinNode_v2 item);

    public class ATNSubjWillBeV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillBeV3NoObjConditionFinNodeFactory_v2(ATNSubjWillBeV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillBeV3NoObjConditionFinNodeFactory_v2(ATNSubjWillBeV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillBeV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillBeV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillBeV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillBeV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillBeV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillBeV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillBeV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillBeV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillBeV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillBeV3NoObjConditionFinNode_v2 sameNode, InitATNSubjWillBeV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Be_V3_No_Obj_Condition_Fin;

        public ATNSubjWillBeV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillBeV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillBeV3NoObjConditionFinNodeAction mInitAction;

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

