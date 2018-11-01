using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjConditionVerbNoObjConditionFinNodeAction(ATNQWSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNQWSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNQWSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNQWSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNQWSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNQWSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNQWSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

