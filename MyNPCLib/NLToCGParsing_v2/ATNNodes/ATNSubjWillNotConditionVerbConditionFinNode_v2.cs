using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotConditionVerbConditionFinNodeAction(ATNSubjWillNotConditionVerbConditionFinNode_v2 item);

    public class ATNSubjWillNotConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotConditionVerbConditionFinNodeFactory_v2(ATNSubjWillNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotConditionVerbConditionFinNodeFactory_v2(ATNSubjWillNotConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotConditionVerbConditionFinNode_v2 sameNode, InitATNSubjWillNotConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Condition_Verb_Condition_Fin;

        public ATNSubjWillNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotConditionVerbConditionFinNodeAction mInitAction;

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

