using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbConditionVerbNoObjConditionFinNodeAction(ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2 item);

    public class ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbConditionVerbNoObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbConditionVerbNoObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2 sameNode, InitATNConditionSubjModalVerbConditionVerbNoObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Condition_Verb_No_Obj_Condition_Fin;

        public ATNConditionSubjModalVerbConditionVerbNoObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbConditionVerbNoObjConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbConditionVerbNoObjConditionFinNodeAction mInitAction;

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

