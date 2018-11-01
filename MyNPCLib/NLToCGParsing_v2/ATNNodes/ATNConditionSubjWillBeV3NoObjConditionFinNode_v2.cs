using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeV3NoObjConditionFinNodeAction(ATNConditionSubjWillBeV3NoObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillBeV3NoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeV3NoObjConditionFinNodeFactory_v2(ATNConditionSubjWillBeV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeV3NoObjConditionFinNodeFactory_v2(ATNConditionSubjWillBeV3NoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeV3NoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeV3NoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillBeV3NoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeV3NoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeV3NoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeV3NoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillBeV3NoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeV3NoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeV3NoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeV3NoObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillBeV3NoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_V3_No_Obj_Condition_Fin;

        public ATNConditionSubjWillBeV3NoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeV3NoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeV3NoObjConditionFinNodeAction mInitAction;

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

