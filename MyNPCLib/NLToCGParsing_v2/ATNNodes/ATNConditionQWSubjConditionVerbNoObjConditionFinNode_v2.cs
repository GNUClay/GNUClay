using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjConditionVerbNoObjConditionFinNodeAction(ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionQWSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

