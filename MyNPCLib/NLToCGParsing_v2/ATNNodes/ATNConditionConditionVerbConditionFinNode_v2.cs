using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionConditionVerbConditionFinNodeAction(ATNConditionConditionVerbConditionFinNode_v2 item);

    public class ATNConditionConditionVerbConditionFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionConditionVerbConditionFinNodeFactory_v2(ATNConditionConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionConditionVerbConditionFinNodeFactory_v2(ATNConditionConditionVerbConditionFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionConditionVerbConditionFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionConditionVerbConditionFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionConditionVerbConditionFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionConditionVerbConditionFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionConditionVerbConditionFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

    public class ATNConditionConditionVerbConditionFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionConditionVerbConditionFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionConditionVerbConditionFinNode_v2 sameNode, InitATNConditionConditionVerbConditionFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Condition_Verb_Condition_Fin;

        public ATNConditionConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionConditionVerbConditionFinNode_v2 mSameNode;
        private InitATNConditionConditionVerbConditionFinNodeAction mInitAction;

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

