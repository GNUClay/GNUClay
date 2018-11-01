using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillVerbNoObjConditionFinNodeAction(ATNConditionSubjWillVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjWillVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillVerbNoObjConditionFinNodeFactory_v2(ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillVerbNoObjConditionFinNodeFactory_v2(ATNConditionSubjWillVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjWillVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Verb_No_Obj_Condition_Fin;

        public ATNConditionSubjWillVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillVerbNoObjConditionFinNodeAction mInitAction;

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

