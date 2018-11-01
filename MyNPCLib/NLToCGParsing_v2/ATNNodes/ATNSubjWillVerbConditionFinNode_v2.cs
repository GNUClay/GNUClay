using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillVerbConditionFinNodeAction(ATNSubjWillVerbConditionFinNode_v2 item);

    public class ATNSubjWillVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillVerbConditionFinNodeFactory_v2(ATNSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillVerbConditionFinNodeFactory_v2(ATNSubjWillVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjWillVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillVerbConditionFinNode_v2 sameNode, InitATNSubjWillVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Verb_Condition_Fin;

        public ATNSubjWillVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillVerbConditionFinNode_v2 mSameNode;
        private InitATNSubjWillVerbConditionFinNodeAction mInitAction;

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

