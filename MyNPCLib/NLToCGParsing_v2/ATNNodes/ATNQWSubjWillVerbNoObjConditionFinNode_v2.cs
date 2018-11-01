using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillVerbNoObjConditionFinNodeAction(ATNQWSubjWillVerbNoObjConditionFinNode_v2 item);

    public class ATNQWSubjWillVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillVerbNoObjConditionFinNodeFactory_v2(ATNQWSubjWillVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillVerbNoObjConditionFinNodeFactory_v2(ATNQWSubjWillVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbNoObjConditionFinNode_v2 sameNode, InitATNQWSubjWillVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Verb_No_Obj_Condition_Fin;

        public ATNQWSubjWillVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillVerbNoObjConditionFinNodeAction mInitAction;

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

