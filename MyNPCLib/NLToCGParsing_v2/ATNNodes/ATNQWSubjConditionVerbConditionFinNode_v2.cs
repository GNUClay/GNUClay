using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNQWSubjConditionVerbConditionFinNodeAction(ATNQWSubjConditionVerbConditionFinNode_v2 item);

    public class ATNQWSubjConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNQWSubjConditionVerbConditionFinNodeFactory_v2(ATNQWSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNQWSubjConditionVerbConditionFinNodeFactory_v2(ATNQWSubjConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNQWSubjConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNQWSubjConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNQWSubjConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNQWSubjConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNQWSubjConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNQWSubjConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNQWSubjConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNQWSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNQWSubjConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNQWSubjConditionVerbConditionFinNode_v2 sameNode, InitATNQWSubjConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.QWSubj_Condition_Verb_Condition_Fin;

        public ATNQWSubjConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNQWSubjConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNQWSubjConditionVerbConditionFinNodeAction mInitAction;

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

