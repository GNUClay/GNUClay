using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjVerbNoObjConditionFinNodeAction(ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionModalVerbSubjVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjVerbNoObjConditionFinNodeFactory_v2(ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjVerbNoObjConditionFinNodeFactory_v2(ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionModalVerbSubjVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Verb_No_Obj_Condition_Fin;

        public ATNConditionModalVerbSubjVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjVerbNoObjConditionFinNodeAction mInitAction;

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

