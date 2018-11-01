using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillVerbConditionFinNodeAction(ATNConditionSubjWillVerbConditionFinNode_v2 item);

    public class ATNConditionSubjWillVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillVerbConditionFinNodeFactory_v2(ATNConditionSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillVerbConditionFinNodeFactory_v2(ATNConditionSubjWillVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbConditionFinNode_v2 sameNode, InitATNConditionSubjWillVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Verb_Condition_Fin;

        public ATNConditionSubjWillVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillVerbConditionFinNodeAction mInitAction;

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

