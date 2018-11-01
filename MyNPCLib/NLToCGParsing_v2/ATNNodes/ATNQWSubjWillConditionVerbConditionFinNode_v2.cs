using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjWillConditionVerbConditionFinNodeAction(ATNQWSubjWillConditionVerbConditionFinNode_v2 item);

    public class ATNQWSubjWillConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjWillConditionVerbConditionFinNodeFactory_v2(ATNQWSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjWillConditionVerbConditionFinNodeFactory_v2(ATNQWSubjWillConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjWillConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjWillConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjWillConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjWillConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjWillConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjWillConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjWillConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjWillConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjWillConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjWillConditionVerbConditionFinNode_v2 sameNode, InitATNQWSubjWillConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Will_Condition_Verb_Condition_Fin;

        public ATNQWSubjWillConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjWillConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNQWSubjWillConditionVerbConditionFinNodeAction mInitAction;

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

