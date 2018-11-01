using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNModalVerbSubjConditionVerbConditionFinNodeAction(ATNModalVerbSubjConditionVerbConditionFinNode_v2 item);

    public class ATNModalVerbSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNModalVerbSubjConditionVerbConditionFinNodeFactory_v2(ATNModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNModalVerbSubjConditionVerbConditionFinNodeFactory_v2(ATNModalVerbSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNModalVerbSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNModalVerbSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNModalVerbSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNModalVerbSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNModalVerbSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNModalVerbSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNModalVerbSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNModalVerbSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNModalVerbSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNModalVerbSubjConditionVerbConditionFinNode_v2 sameNode, InitATNModalVerbSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.ModalVerb_Subj_Condition_Verb_Condition_Fin;

        public ATNModalVerbSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNModalVerbSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNModalVerbSubjConditionVerbConditionFinNodeAction mInitAction;

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

