using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbVerbNoObjConditionFinNodeAction(ATNSubjModalVerbVerbNoObjConditionFinNode_v2 item);

    public class ATNSubjModalVerbVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbVerbNoObjConditionFinNodeFactory_v2(ATNSubjModalVerbVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbVerbNoObjConditionFinNodeFactory_v2(ATNSubjModalVerbVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjModalVerbVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbVerbNoObjConditionFinNode_v2 sameNode, InitATNSubjModalVerbVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Verb_No_Obj_Condition_Fin;

        public ATNSubjModalVerbVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNSubjModalVerbVerbNoObjConditionFinNodeAction mInitAction;

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

