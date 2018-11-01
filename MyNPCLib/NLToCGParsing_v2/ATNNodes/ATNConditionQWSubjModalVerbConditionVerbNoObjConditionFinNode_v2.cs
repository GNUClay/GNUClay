using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNodeAction(ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionQWSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbConditionVerbNoObjConditionFinNodeAction mInitAction;

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

