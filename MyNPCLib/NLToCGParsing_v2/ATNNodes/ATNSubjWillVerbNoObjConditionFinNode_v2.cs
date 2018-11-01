using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillVerbNoObjConditionFinNodeAction(ATNSubjWillVerbNoObjConditionFinNode_v2 item);

    public class ATNSubjWillVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillVerbNoObjConditionFinNodeFactory_v2(ATNSubjWillVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillVerbNoObjConditionFinNodeFactory_v2(ATNSubjWillVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjWillVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbNoObjConditionFinNode_v2 sameNode, InitATNSubjWillVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Verb_No_Obj_Condition_Fin;

        public ATNSubjWillVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjWillVerbNoObjConditionFinNodeAction mInitAction;

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

