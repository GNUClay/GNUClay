using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillVerbConditionFinNodeAction(ATNQWSubjWillVerbConditionFinNode_v2 item);

    public class ATNQWSubjWillVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillVerbConditionFinNodeFactory_v2(ATNQWSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillVerbConditionFinNodeFactory_v2(ATNQWSubjWillVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillVerbConditionFinNode_v2 sameNode, InitATNQWSubjWillVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Verb_Condition_Fin;

        public ATNQWSubjWillVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillVerbConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillVerbConditionFinNodeAction mInitAction;

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

