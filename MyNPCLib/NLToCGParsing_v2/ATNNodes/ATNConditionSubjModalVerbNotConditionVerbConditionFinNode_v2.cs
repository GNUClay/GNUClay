using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbNotConditionVerbConditionFinNodeAction(ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2 item);

    public class ATNConditionSubjModalVerbNotConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbNotConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbNotConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbNotConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbNotConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2 sameNode, InitATNConditionSubjModalVerbNotConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Not_Condition_Verb_Condition_Fin;

        public ATNConditionSubjModalVerbNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbNotConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbNotConditionVerbConditionFinNodeAction mInitAction;

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

