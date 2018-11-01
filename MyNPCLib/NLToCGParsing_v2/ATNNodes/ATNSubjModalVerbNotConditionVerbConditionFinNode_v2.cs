using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjModalVerbNotConditionVerbConditionFinNodeAction(ATNSubjModalVerbNotConditionVerbConditionFinNode_v2 item);

    public class ATNSubjModalVerbNotConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjModalVerbNotConditionVerbConditionFinNodeFactory_v2(ATNSubjModalVerbNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjModalVerbNotConditionVerbConditionFinNodeFactory_v2(ATNSubjModalVerbNotConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjModalVerbNotConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjModalVerbNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjModalVerbNotConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjModalVerbNotConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjModalVerbNotConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjModalVerbNotConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjModalVerbNotConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjModalVerbNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjModalVerbNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjModalVerbNotConditionVerbConditionFinNode_v2 sameNode, InitATNSubjModalVerbNotConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_ModalVerb_Not_Condition_Verb_Condition_Fin;

        public ATNSubjModalVerbNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjModalVerbNotConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNSubjModalVerbNotConditionVerbConditionFinNodeAction mInitAction;

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

