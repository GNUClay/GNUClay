using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjConditionVerbNoObjConditionFinNodeAction(ATNSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

