using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbVerbNoObjConditionFinNodeAction(ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionQWSubjModalVerbVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbVerbNoObjConditionFinNodeFactory_v2(ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionQWSubjModalVerbVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Verb_No_Obj_Condition_Fin;

        public ATNConditionQWSubjModalVerbVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbVerbNoObjConditionFinNodeAction mInitAction;

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

