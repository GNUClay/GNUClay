using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjVerbNoObjConditionFinNodeAction(ATNModalVerbSubjVerbNoObjConditionFinNode_v2 item);

    public class ATNModalVerbSubjVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjVerbNoObjConditionFinNodeFactory_v2(ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjVerbNoObjConditionFinNodeFactory_v2(ATNModalVerbSubjVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNModalVerbSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNModalVerbSubjVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjVerbNoObjConditionFinNode_v2 sameNode, InitATNModalVerbSubjVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Verb_No_Obj_Condition_Fin;

        public ATNModalVerbSubjVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNModalVerbSubjVerbNoObjConditionFinNodeAction mInitAction;

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

