using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbConditionVerbConditionFinNodeAction(ATNSubjModalVerbConditionVerbConditionFinNode_v2 item);

    public class ATNSubjModalVerbConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbConditionVerbConditionFinNodeFactory_v2(ATNSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbConditionVerbConditionFinNodeFactory_v2(ATNSubjModalVerbConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjModalVerbConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbConditionVerbConditionFinNode_v2 sameNode, InitATNSubjModalVerbConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Condition_Verb_Condition_Fin;

        public ATNSubjModalVerbConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNSubjModalVerbConditionVerbConditionFinNodeAction mInitAction;

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

