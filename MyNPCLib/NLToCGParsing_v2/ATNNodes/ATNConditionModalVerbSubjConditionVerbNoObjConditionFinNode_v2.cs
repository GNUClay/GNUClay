using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjConditionVerbNoObjConditionFinNodeAction(ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionModalVerbSubjConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionModalVerbSubjConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjConditionVerbNoObjConditionFinNodeAction mInitAction;

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

