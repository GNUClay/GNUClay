using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillConditionVerbConditionFinNodeAction(ATNConditionSubjWillConditionVerbConditionFinNode_v2 item);

    public class ATNConditionSubjWillConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillConditionVerbConditionFinNodeFactory_v2(ATNConditionSubjWillConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionSubjWillConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillConditionVerbConditionFinNode_v2 sameNode, InitATNConditionSubjWillConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Condition_Verb_Condition_Fin;

        public ATNConditionSubjWillConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionSubjWillConditionVerbConditionFinNodeAction mInitAction;

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

