using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotVerbConditionFinNodeAction(ATNConditionSubjWillNotVerbConditionFinNode_v2 item);

    public class ATNConditionSubjWillNotVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotVerbConditionFinNodeFactory_v2(ATNConditionSubjWillNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotVerbConditionFinNodeFactory_v2(ATNConditionSubjWillNotVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillNotVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillNotVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotVerbConditionFinNode_v2 sameNode, InitATNConditionSubjWillNotVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Verb_Condition_Fin;

        public ATNConditionSubjWillNotVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotVerbConditionFinNodeAction mInitAction;

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

