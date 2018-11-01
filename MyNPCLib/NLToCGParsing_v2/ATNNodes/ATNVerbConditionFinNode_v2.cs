using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNVerbConditionFinNodeAction(ATNVerbConditionFinNode_v2 item);

    public class ATNVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNVerbConditionFinNodeFactory_v2(ATNVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNVerbConditionFinNodeFactory_v2(ATNVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNVerbTransOrFinNode_v2 mParentNode;
        private ATNVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNVerbConditionFinNode_v2 sameNode, InitATNVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Verb_Condition_Fin;

        public ATNVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNVerbConditionFinNode_v2 mSameNode;
        private InitATNVerbConditionFinNodeAction mInitAction;

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

