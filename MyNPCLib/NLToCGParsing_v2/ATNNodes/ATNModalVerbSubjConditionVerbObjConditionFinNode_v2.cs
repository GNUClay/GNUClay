using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjConditionVerbObjConditionFinNodeAction(ATNModalVerbSubjConditionVerbObjConditionFinNode_v2 item);

    public class ATNModalVerbSubjConditionVerbObjConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjConditionVerbObjConditionFinNodeFactory_v2(ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjConditionVerbObjConditionFinNodeFactory_v2(ATNModalVerbSubjConditionVerbObjConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjConditionVerbObjConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 mParentNode;
        private ATNModalVerbSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjConditionVerbObjConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjConditionVerbObjConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjConditionVerbObjConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNModalVerbSubjConditionVerbObjConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjConditionVerbObjConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbObjConditionFinNode_v2 sameNode, InitATNModalVerbSubjConditionVerbObjConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Condition_Verb_Obj_Condition_Fin;

        public ATNModalVerbSubjConditionVerbObjTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjConditionVerbObjConditionFinNode_v2 mSameNode;
        private InitATNModalVerbSubjConditionVerbObjConditionFinNodeAction mInitAction;

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

