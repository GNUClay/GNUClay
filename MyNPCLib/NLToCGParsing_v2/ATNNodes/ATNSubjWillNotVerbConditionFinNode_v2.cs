using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotVerbConditionFinNodeAction(ATNSubjWillNotVerbConditionFinNode_v2 item);

    public class ATNSubjWillNotVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotVerbConditionFinNodeFactory_v2(ATNSubjWillNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotVerbConditionFinNodeFactory_v2(ATNSubjWillNotVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotVerbTransOrFinNode_v2 mParentNode;
        private ATNSubjWillNotVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNSubjWillNotVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotVerbConditionFinNode_v2 sameNode, InitATNSubjWillNotVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_Verb_Condition_Fin;

        public ATNSubjWillNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotVerbConditionFinNode_v2 mSameNode;
        private InitATNSubjWillNotVerbConditionFinNodeAction mInitAction;

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

