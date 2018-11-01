using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotConditionVerbConditionFinNodeAction(ATNConditionSubjWillNotConditionVerbConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjWillNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjWillNotConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotConditionVerbConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Condition_Verb_Condition_Fin;

        public ATNConditionSubjWillNotConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotConditionVerbConditionFinNodeAction mInitAction;

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

