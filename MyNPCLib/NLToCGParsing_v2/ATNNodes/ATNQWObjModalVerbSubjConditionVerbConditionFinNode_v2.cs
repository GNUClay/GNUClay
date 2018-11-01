using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWObjModalVerbSubjConditionVerbConditionFinNodeAction(ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2 item);

    public class ATNQWObjModalVerbSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWObjModalVerbSubjConditionVerbConditionFinNodeFactory_v2(ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWObjModalVerbSubjConditionVerbConditionFinNodeFactory_v2(ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWObjModalVerbSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWObjModalVerbSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2 sameNode, InitATNQWObjModalVerbSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWObj_ModalVerb_Subj_Condition_Verb_Condition_Fin;

        public ATNQWObjModalVerbSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWObjModalVerbSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNQWObjModalVerbSubjConditionVerbConditionFinNodeAction mInitAction;

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

